namespace Base.Datos.DAL
{
    #region Importaciones
    using System;
    using AutoMapper;
    using Base.IC.DTO.Entidades;
    using System.Threading.Tasks;
    using Base.Transversal.Clases;
    using Base.Datos.Configuracion;
    using Base.Transversal.Mensajes;
    using System.Collections.Generic;
    using Base.IC.Acciones.Entidades;
    using Base.Datos.Contexto.Entidades;
    using Microsoft.EntityFrameworkCore;
    #endregion Fin Importaciones
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
                => await EjecutarTransaccionAsync(async () =>
                {
                    List<Persona> persona = await context.Personas.AsNoTracking().ToListAsync();
                    if (IsNull(persona))
                        return CrearRespuesta<IPersonaDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                    return CrearRespuesta<IPersonaDTO>.ExitosaLista(MapListIPersonaDTO(persona));
                });

        public async Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    personaDO = await context.Personas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(personaDO.Id));
                    if (IsNull(personaDO))
                        return CrearRespuesta<IPersonaDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                    return CrearRespuesta<IPersonaDTO>.Exitosa(MapIPersonaDTO(personaDO), MensajesBaseEspanol.SuccessfulConsultation);
                });

        public async Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    context.Entry(personaDO).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return CrearRespuesta<IPersonaDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData);
                });

        public async Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    context.Personas.Remove(personaDO);
                    await context.SaveChangesAsync();
                    return CrearRespuesta<IPersonaDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                });

        public async Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
                => await EjecutarTransaccionAsync(async () =>
                {
                    Persona personaDO = MapPersona(persona);
                    
                    context.Personas.Add(personaDO);
                    await context.SaveChangesAsync();
                    return CrearRespuesta<IPersonaDTO>.Exitosa(null, MensajesBaseEspanol.CreateData);
                });

        #region Metodos Privados

        private Persona MapPersona(IPersonaDTO persona)
            => mapper.Map<IPersonaDTO, Persona>(persona);

        private IPersonaDTO MapIPersonaDTO(Persona persona)
            => mapper.Map<Persona, IPersonaDTO>(persona);

        private List<IPersonaDTO> MapListIPersonaDTO(List<Persona> persona)
            => mapper.Map<List<Persona>, List<IPersonaDTO>>(persona);

        #endregion Fin Metodos Privados
    }
}
