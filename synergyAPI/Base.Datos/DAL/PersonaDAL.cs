namespace Base.Datos.DAL
{
    #region Importaciones

    using AutoMapper;
    using Base.Datos.Configuracion;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using Base.Transversal.Mensajes;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
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
            => await EjecutarTransaccionAsync(async () =>
               {
                   List<Persona> personas = await context.Personas.AsNoTracking().ToListAsync();
                   if (IsNull(personas))
                       return CrearRespuesta<IPersonaDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);

                   return CrearRespuesta<IPersonaDTO>.ExitosaLista(MapListIPersonaDTO(personas));
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
                    }, context, nameof(PersonaDAL.EliminarPersona));

        public async Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () =>
               {
                   Persona personaDO = MapPersona(persona);
                   personaDO.Id = Guid.NewGuid();
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

        #endregion Metodos Privados
    }
}