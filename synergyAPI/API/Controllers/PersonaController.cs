namespace API.Controllers
{
    using API.CO.Entidades;
    using AutoMapper;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BL;
    using Base.Transversal.Clases;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]

    public class PersonaController : AccesoComun
    {
        private readonly PersonaBL personaBL;
        private readonly IMapper mapper;

        public PersonaController(PersonaBL personaBL, IMapper mapper)
        {
            this.personaBL = personaBL;
            this.mapper = mapper;
        }

        /// <summary>
        ///     Consultar lista de personas.
        /// </summary>
        /// <author>Marlon León</author>
        [HttpGet]
        [Route(nameof(PersonaController.ConsultarListaPersona))]
        public async Task<Respuesta<List<PersonaDTO>>> ConsultarListaPersona()
        {
            return mapper.Map<Respuesta<List<IPersonaDTO>>, Respuesta<List<PersonaDTO>>>(await personaBL.ConsultarListaPersona());
        }

        /// <summary>
        ///     Consultar una persona.
        /// </summary>
        /// <author>Marlon León</author>
        /// <param name="persona">DTO persona</param>
        [HttpPost]
        [Route(nameof(PersonaController.ConsultarPersona))]
        public async Task<Respuesta<PersonaDTO>> ConsultarPersona([FromBody] PersonaDTO persona)
        {
            if (ObjIsNull(persona) || !TryValidateModel(persona))
                return CrearRespuesta<PersonaDTO>.Fallida(MensajeError());

            return mapper.Map<Respuesta<IPersonaDTO>, Respuesta<PersonaDTO>>(await personaBL.ConsultarPersona(mapper.Map<PersonaDTO, IPersonaDTO>(persona)));
        }

        //public Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona)
        //{
        //    throw new System.NotImplementedException();
        //}

        private string MensajeError()
        {
            return ModelState.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .First().First().ErrorMessage.ToString();
        }
    }
}