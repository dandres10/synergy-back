namespace API.Controllers
{
    using API.CO.Entidades;
    using AutoMapper;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BL;
    using Base.Transversal.Clases;
    using Microsoft.AspNetCore.Mvc;
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

        //public Task<Respuesta<IPersonaDTO>> ConsultarListaPersona(IPersonaDTO persona)
        //{
        //    throw new System.NotImplementedException();
        //}

        /// <summary>
        ///     Consultar una persona.
        /// </summary>
        /// <author>Marlon León</author>
        /// <param name="persona">DTO persona</param>
        [HttpPost]
        [Route(nameof(PersonaController.ConsultarPersona))]
        public async Task<Respuesta<PersonaCO>> ConsultarPersona([FromBody] PersonaCO persona)
        {
            if (ObjIsNull(persona) || !TryValidateModel(persona))
                return CrearRespuesta<PersonaCO>.Fallida(MensajeError());

            return mapper.Map<Respuesta<IPersonaDTO>, Respuesta<PersonaCO>>(await personaBL.ConsultarPersona(persona));
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