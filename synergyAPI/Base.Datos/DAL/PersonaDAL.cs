namespace Base.Datos.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using Base.Transversal.Mensajes;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class PersonaDAL : AccesoComun, IPersonaAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private Persona persona;

        public PersonaDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            persona = new Persona();
        }

        public Task<Respuesta<IPersonaDTO>> ConsultarListaPersona(IPersonaDTO persona)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona)
        {
            return await EjecutarTransaccionAsync(async () =>
            {
                persona = await context.Personas.FirstOrDefaultAsync(x => x.Id.Equals(persona.Id));
                if (ObjIsNull(persona))
                    return CrearRespuesta<IPersonaDTO>.Advertencia(persona, MensajesBaseEspanol.NoData);

                return CrearRespuesta<IPersonaDTO>.Exitosa(persona);
            });
        }

        public Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
        {
            throw new NotImplementedException();
        }
    }
}