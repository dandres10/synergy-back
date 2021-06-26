namespace Base.Negocio.BL
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.Datos.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.Configuracion;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PersonaBL : AccesoComunBL, IPersonaAccion
    {
        private readonly PersonaDAL personaDAL;
        private readonly IMapper mapper;
        private readonly Context context;

        public PersonaBL(PersonaDAL personaDAL, IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
            this.personaDAL = personaDAL;
        }

        public async Task<Respuesta<List<IPersonaDTO>>> ConsultarListaPersona()
             => await EjecutarTransaccionAsync(async () => await personaDAL.ConsultarListaPersona());

        public async Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () => await personaDAL.ConsultarPersona(persona));

        public async Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IPersonaDTO> respuestaDAL = await personaDAL.ConsultarPersona(persona);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await personaDAL.EditarPersona(persona);
            });

        public async Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IPersonaDTO> respuestaDAL = await personaDAL.ConsultarPersona(persona);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await personaDAL.EliminarPersona(persona);
            });

        public async Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
            => await EjecutarTransaccionAsync(async () => await personaDAL.GuardarPersona(persona));
    }
}