namespace API.Controllers
{
    #region Importaciones

    using API.Configuracion;
    using API.DTO.Entidades.Personasede;
    using AutoMapper;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BL;
    using Base.Transversal.Clases;
    using Base.Transversal.Mensajes;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion Importaciones

    [Route(RutaBase)]
    public class PersonasedeController : AccesoComun
    {
        private readonly PersonasedeBL personasedeBL;
        private readonly IMapper mapper;

        public PersonasedeController(PersonasedeBL personasedeBL, IMapper mapper)
        {
            this.personasedeBL = personasedeBL;
            this.mapper = mapper;
        }

        #region Puntos de acceso

        /// <summary>
        ///     Consultar lista personasede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        [HttpGet]
        [Route(nameof(PersonasedeController.ConsultarListaPersonasede))]
        public async Task<Respuesta<List<PersonasedeDTO>>> ConsultarListaPersonasede()
           => MapRespuestaListPersonasedeDTO(await personasedeBL.ConsultarListaPersonasede());

        /// <summary>
        ///     Consultar personasede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personasede">DTO personasede</param>
        [HttpPost]
        [Route(nameof(PersonasedeController.ConsultarPersonasede))]
        public async Task<Respuesta<PersonasedeDTO>> ConsultarPersonasede([FromBody] PersonasedeDTO personasede)
        {
            if (EntidadValida(personasede))
                return CrearRespuesta<PersonasedeDTO>.Fallida(MensajeError());
            return MapRespuestaPersonasedeDTO(await personasedeBL.ConsultarPersonasede(mapper.Map<PersonasedeDTO, IPersonasedeDTO>(personasede)));
        }

        /// <summary>
        ///     Editar personasede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personasede">DTO personasede</param>
        [HttpPost]
        [Route(nameof(PersonasedeController.EditarPersonasede))]
        public async Task<Respuesta<EditarPersonasedeDTO>> EditarPersonasede([FromBody] EditarPersonasedeDTO personasede)
        {
            if (EntidadValida(personasede))
                return CrearRespuesta<EditarPersonasedeDTO>.Fallida(MensajeError());
            return MapRespuestaEditarPersonasedeDTO(await personasedeBL.EditarPersonasede(mapper.Map<EditarPersonasedeDTO, IPersonasedeDTO>(personasede)));
        }

        /// <summary>
        ///     Eliminar personasede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personasede">DTO personasede</param>
        [HttpPost]
        [Route(nameof(PersonasedeController.EliminarPersonasede))]
        public async Task<Respuesta<PersonasedeDTO>> EliminarPersonasede([FromBody] PersonasedeDTO personasede)
        {
            if (EntidadValida(personasede))
                return CrearRespuesta<PersonasedeDTO>.Fallida(MensajeError());
            return MapRespuestaPersonasedeDTO(await personasedeBL.EliminarPersonasede(mapper.Map<PersonasedeDTO, IPersonasedeDTO>(personasede)));
        }

        /// <summary>
        ///     Guardar personasede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personasede">DTO personasede</param>
        [HttpPost]
        [Route(nameof(PersonasedeController.GuardarPersonasede))]
        public async Task<Respuesta<GuardarPersonasedeDTO>> GuardarPersonasede([FromBody] GuardarPersonasedeDTO personasede)
        {
            if (EntidadValida(personasede))
                return CrearRespuesta<GuardarPersonasedeDTO>.Fallida(MensajeError());
            return MapRespuestaGuardarPersonasedeDTO(await personasedeBL.GuardarPersonasede(mapper.Map<GuardarPersonasedeDTO, IPersonasedeDTO>(personasede)));
        }

        #endregion Puntos de acceso

        #region Metodos Privados

        private Respuesta<PersonasedeDTO> MapRespuestaPersonasedeDTO(Respuesta<IPersonasedeDTO> personasede)
            => mapper.Map<Respuesta<IPersonasedeDTO>, Respuesta<PersonasedeDTO>>(personasede);

        private Respuesta<EditarPersonasedeDTO> MapRespuestaEditarPersonasedeDTO(Respuesta<IPersonasedeDTO> personasede)
            => mapper.Map<Respuesta<IPersonasedeDTO>, Respuesta<EditarPersonasedeDTO>>(personasede);

        private Respuesta<GuardarPersonasedeDTO> MapRespuestaGuardarPersonasedeDTO(Respuesta<IPersonasedeDTO> personasede)
            => mapper.Map<Respuesta<IPersonasedeDTO>, Respuesta<GuardarPersonasedeDTO>>(personasede);

        private Respuesta<List<PersonasedeDTO>> MapRespuestaListPersonasedeDTO(Respuesta<List<IPersonasedeDTO>> personasede)
            => mapper.Map<Respuesta<List<IPersonasedeDTO>>, Respuesta<List<PersonasedeDTO>>>(personasede);

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