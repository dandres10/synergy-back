namespace API.Controllers
{
    #region Importaciones

    using API.Configuracion;
    using API.DTO.Consultas;
    using API.DTO.Entidades.Persona;
    using AutoMapper;
    using Base.IC.DTO.Consultas;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BL;
    using Base.Transversal.Clases;
    using Base.Transversal.Enumeraciones;
    using Base.Transversal.Mensajes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion Importaciones

    [Route(RutaBase)]
    public class PersonaController : AccesoComun
    {
        private readonly PersonaBL personaBL;
        private readonly IMapper mapper;

        public PersonaController(PersonaBL personaBL, IMapper mapper)
        {
            this.personaBL = personaBL;
            this.mapper = mapper;
        }

        #region Puntos de acceso

        /// <summary>
        ///     Consultar lista persona.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        [HttpGet]
        [Authorize]
        [Route(nameof(PersonaController.ConsultarListaPersona))]
        public async Task<Respuesta<List<PersonaDTO>>> ConsultarListaPersona()
           => MapRespuestaListPersonaDTO(await personaBL.ConsultarListaPersona());

        /// <summary>
        ///     Consultar persona.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="persona">DTO persona</param>
        [HttpPost]
        [Authorize]
        [Route(nameof(PersonaController.ConsultarPersona))]
        public async Task<Respuesta<PersonaDTO>> ConsultarPersona([FromBody] PersonaDTO persona)
        {
            if (EntidadValida(persona))
                return CrearRespuesta<PersonaDTO>.Fallida(MensajeError());
            return MapRespuestaPersonaDTO(await personaBL.ConsultarPersona(mapper.Map<PersonaDTO, IPersonaDTO>(persona)));
        }

        /// <summary>
        ///     Editar persona.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="persona">DTO persona</param>
        [HttpPost]
        [Authorize]
        [Route(nameof(PersonaController.EditarPersona))]
        public async Task<Respuesta<EditarPersonaDTO>> EditarPersona([FromBody] EditarPersonaDTO persona)
        {
            if (EntidadValida(persona))
                return CrearRespuesta<EditarPersonaDTO>.Fallida(MensajeError());
            return MapRespuestaEditarPersonaDTO(await personaBL.EditarPersona(mapper.Map<EditarPersonaDTO, IPersonaDTO>(persona)));
        }

        /// <summary>
        ///     Eliminar persona.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="persona">DTO persona</param>
        [HttpPost]
        [Authorize]
        [Route(nameof(PersonaController.EliminarPersona))]
        public async Task<Respuesta<PersonaDTO>> EliminarPersona([FromBody] PersonaDTO persona)
        {
            if (EntidadValida(persona))
                return CrearRespuesta<PersonaDTO>.Fallida(MensajeError());
            return MapRespuestaPersonaDTO(await personaBL.EliminarPersona(mapper.Map<PersonaDTO, IPersonaDTO>(persona)));
        }

        /// <summary>
        ///     Guardar persona.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="persona">DTO persona</param>
        [HttpPost]
        //[Authorize]
        [Route(nameof(PersonaController.GuardarPersona))]
        public async Task<Respuesta<GuardarPersonaDTO>> GuardarPersona([FromBody] GuardarPersonaDTO persona)
        {
            if (EntidadValida(persona))
                return CrearRespuesta<GuardarPersonaDTO>.Fallida(MensajeError());
            return MapRespuestaGuardarPersonaDTO(await personaBL.GuardarPersona(mapper.Map<GuardarPersonaDTO, IPersonaDTO>(persona)));
        }

        /// <summary>
        ///     Autenticar persona.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personaLogin">DTO personaLogin</param>
        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(PersonaController.AutenticarPersona))]
        public async Task<Respuesta<PersonaLoginTokenDTO>> AutenticarPersona([FromBody] PersonaLoginDTO personaLogin)
        {
            if (EntidadValida(personaLogin))
                return CrearRespuesta<PersonaLoginTokenDTO>.Fallida(MensajeError(),TipoMensaje.MensajeEstatico);

            return mapper.Map<Respuesta<IPersonaLoginTokenDTO>, Respuesta<PersonaLoginTokenDTO>>(await personaBL.AutenticarPersona(mapper.Map<PersonaLoginDTO, IPersonaLoginDTO>(personaLogin)));
        }

        #endregion Puntos de acceso

        #region Metodos Privados

        private Respuesta<PersonaDTO> MapRespuestaPersonaDTO(Respuesta<IPersonaDTO> persona)
            => mapper.Map<Respuesta<IPersonaDTO>, Respuesta<PersonaDTO>>(persona);

        private Respuesta<EditarPersonaDTO> MapRespuestaEditarPersonaDTO(Respuesta<IPersonaDTO> persona)
            => mapper.Map<Respuesta<IPersonaDTO>, Respuesta<EditarPersonaDTO>>(persona);

        private Respuesta<GuardarPersonaDTO> MapRespuestaGuardarPersonaDTO(Respuesta<IPersonaDTO> persona)
            => mapper.Map<Respuesta<IPersonaDTO>, Respuesta<GuardarPersonaDTO>>(persona);

        private Respuesta<List<PersonaDTO>> MapRespuestaListPersonaDTO(Respuesta<List<IPersonaDTO>> persona)
            => mapper.Map<Respuesta<List<IPersonaDTO>>, Respuesta<List<PersonaDTO>>>(persona);

        private bool EntidadValida<T>(T entidad)
         => IsNull(entidad) || !TryValidateModel(entidad);

        private string MensajeError()
         => ModelState.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .First().First().ErrorMessage.ToString() ??
                             MensajesBaseEspanol.UnidentifiedError;

        #endregion Metodos Privados
    }
}