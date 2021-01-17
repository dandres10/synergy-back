namespace Base.Negocio.BL
{
    using AutoMapper;
    using Base.Datos.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System.Threading.Tasks;

    public class PersonaBL : IPersonaAccion
    {
        private readonly PersonaDAL personaDAL;
        private readonly IMapper mapper;

        public PersonaBL(PersonaDAL personaDAL, IMapper mapper)
        {
            this.personaDAL = personaDAL;
            this.mapper = mapper;
        }

        public Task<Respuesta<IPersonaDTO>> ConsultarListaPersona(IPersonaDTO persona)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona)
        {
            return await personaDAL.ConsultarPersona(persona);
        }

        public Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona)
        {
            throw new System.NotImplementedException();
        }

        public Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona)
        {
            throw new System.NotImplementedException();
        }

        public Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
        {
            throw new System.NotImplementedException();
        }
    }
}