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
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PersonaDAL : AccesoComun, IPersonaAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PersonaDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<IPersonaDTO>>> ConsultarListaPersona()
        {
            return await EjecutarTransaccionAsync(async () =>
            {
                List<Persona> personas = await context.Personas.ToListAsync();
                if (ObjIsNull(personas))
                    return CrearRespuesta<IPersonaDTO>.AdvertenciaLista(mapper.Map<List<Persona>, List<IPersonaDTO>>(personas), MensajesBaseEspanol.NoData);

                return CrearRespuesta<IPersonaDTO>.ExitosaLista(mapper.Map<List<IPersonaDTO>>(personas));
            });
        }

        public async Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona)
        {
            return await EjecutarTransaccionAsync(async () =>
            {
                Persona personaDO = mapper.Map<IPersonaDTO, Persona>(persona);
                personaDO = await context.Personas.FirstOrDefaultAsync(x => x.Id.Equals(personaDO.Id));
                if (ObjIsNull(personaDO))
                    return CrearRespuesta<IPersonaDTO>.Advertencia(mapper.Map<Persona, IPersonaDTO>(personaDO), MensajesBaseEspanol.NoData);

                return CrearRespuesta<IPersonaDTO>.Exitosa(mapper.Map<IPersonaDTO>(personaDO));
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