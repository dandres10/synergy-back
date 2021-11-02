namespace Base.Datos.DAL
{
    #region Importaciones

    using AutoMapper;
    using Base.Datos.Configuracion;
    using Base.Datos.Contexto.Entidades;
    using Base.Datos.DO.Consultas;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Consultas;
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using Base.Transversal.Mensajes;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion Importaciones

    public class PersonaDAL : AccesoComunDAL, IPersonaAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PersonaDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<IPersonaDTO>>> ConsultarListaPersona()
                => await EjecutarTransaccionAsync<List<IPersonaDTO>>(async () =>
                {
                    List<Persona> persona = await context.Personas.AsNoTracking().ToListAsync();
                    if (IsNull(persona))
                        return CrearRespuesta<IPersonaDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                    return CrearRespuesta<IPersonaDTO>.ExitosaLista(MapListIPersonaDTO(persona));
                });

        public async Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync<IPersonaDTO>(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    personaDO = await context.Personas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(personaDO.Id));
                    if (IsNull(personaDO))
                        return CrearRespuesta<IPersonaDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                    return CrearRespuesta<IPersonaDTO>.Exitosa(MapIPersonaDTO(personaDO), MensajesBaseEspanol.SuccessfulConsultation);
                });

        public async Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync<IPersonaDTO>(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    context.Entry(personaDO).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return CrearRespuesta<IPersonaDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData);
                });

        public async Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync<IPersonaDTO>(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    context.Personas.Remove(personaDO);
                    await context.SaveChangesAsync();
                    return CrearRespuesta<IPersonaDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                });

        public async Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync<IPersonaDTO>(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    personaDO.Id = Guid.NewGuid();
                    context.Personas.Add(personaDO);
                    await context.SaveChangesAsync();
                    return CrearRespuesta<IPersonaDTO>.Exitosa(MapIPersonaDTO(personaDO), MensajesBaseEspanol.CreateData);
                });

        public async Task<Respuesta<IPersonaInfoDTO>> AutenticarPersona(IPersonaLoginDTO persona)
                => await EjecutarTransaccionAsync<IPersonaInfoDTO>(async () =>
                {
                    PersonaLoginDO personaLoginDO = mapper.Map<IPersonaLoginDTO, PersonaLoginDO>(persona);

                    PersonaInfoDO personaInfoDO = await context.Personas
                                               .Include(i => i.GrupoRols)
                                               .Include(i => i.PersonaEmpresas)
                                               .Where(w => w.Correo.ToLower().Equals(personaLoginDO.Correo.ToLower()) &&
                                                           w.Contrasena.Equals(personaLoginDO.Contrasena) &&
                                                           w.Estado == true)
                                               .Select(s => new PersonaInfoDO
                                               {
                                                   Id = s.Id,
                                                   Nombres = string.Format("{0} {1}", s.PrimerNombre, s.SegundoNombre),
                                                   Apellidos = string.Format("{0} {1}", s.PrimerApellido, s.SegundoApellido),
                                                   Correo = s.Correo,
                                                   NombreRoles = s.GrupoRols.Where(w => w.RolNavigation.Estado == true)
                                                                      .Select(gs => gs.RolNavigation.Nombre).ToList(),
                                                   CodigoRoles = s.GrupoRols.Where(w => w.RolNavigation.Estado == true)
                                                                      .Select(gs => gs.RolNavigation.Codigo.ToString()).ToList(),
                                                   Estado = s.Estado ?? false,
                                                   Empresa = s.PersonaEmpresas.Select(s => s.Empresa).ToList()
                                               }).FirstOrDefaultAsync();

                    if (IsNull(personaInfoDO))
                        return CrearRespuesta<IPersonaInfoDTO>.Fallida(MensajesBaseEspanol.NoData);

                    return CrearRespuesta<IPersonaInfoDTO>.Exitosa(mapper.Map<PersonaInfoDO, IPersonaInfoDTO>(personaInfoDO), null);
                });

        #region Metodos Privados

        private Persona MapPersona(IPersonaDTO persona)
            => mapper.Map<IPersonaDTO, Persona>(persona);

        private IPersonaDTO MapIPersonaDTO(Persona persona)
            => mapper.Map<Persona, IPersonaDTO>(persona);

        private List<IPersonaDTO> MapListIPersonaDTO(List<Persona> persona)
            => mapper.Map<List<Persona>, List<IPersonaDTO>>(persona);

        #endregion Metodos Privados
    }
}