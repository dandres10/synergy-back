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

    public class PersonaempresaBL : AccesoComunBL, IPersonaempresaAccion
    {
        private readonly PersonaempresaDAL personaempresaDAL;
        private readonly IMapper mapper;
        private readonly Context context;

        public PersonaempresaBL(PersonaempresaDAL personaempresaDAL, IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
            this.personaempresaDAL = personaempresaDAL;
        }

        public async Task<Respuesta<List<IPersonaempresaDTO>>> ConsultarListaPersonaempresa()
             => await EjecutarTransaccionAsync<List<IPersonaempresaDTO>>(async () => await personaempresaDAL.ConsultarListaPersonaempresa());

        public async Task<Respuesta<IPersonaempresaDTO>> ConsultarPersonaempresa(IPersonaempresaDTO personaempresa)
            => await EjecutarTransaccionAsync<IPersonaempresaDTO>(async () => await personaempresaDAL.ConsultarPersonaempresa(personaempresa));

        public async Task<Respuesta<IPersonaempresaDTO>> EditarPersonaempresa(IPersonaempresaDTO personaempresa)
            => await EjecutarTransaccionAsync<IPersonaempresaDTO>(async () =>
            {
                Respuesta<IPersonaempresaDTO> respuestaDAL = await personaempresaDAL.ConsultarPersonaempresa(personaempresa);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await personaempresaDAL.EditarPersonaempresa(personaempresa);
            });

        public async Task<Respuesta<IPersonaempresaDTO>> EliminarPersonaempresa(IPersonaempresaDTO personaempresa)
            => await EjecutarTransaccionAsync<IPersonaempresaDTO>(async () =>
             {
                 Respuesta<IPersonaempresaDTO> respuestaDAL = await personaempresaDAL.ConsultarPersonaempresa(personaempresa);
                 if (!respuestaDAL.EsValido) return respuestaDAL;
                 return await personaempresaDAL.EliminarPersonaempresa(personaempresa);
             });

        public async Task<Respuesta<IPersonaempresaDTO>> GuardarPersonaempresa(IPersonaempresaDTO personaempresa)
            => await EjecutarTransaccionAsync<IPersonaempresaDTO>(async () => await personaempresaDAL.GuardarPersonaempresa(personaempresa));
    }
}