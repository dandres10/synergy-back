namespace API.Controllers
{
    #region Importaciones

    using API.Configuracion;
    using API.DTO.Entidades.Sede;
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
    public class SedeController : AccesoComun
    {
        private readonly SedeBL sedeBL;
        private readonly IMapper mapper;

        public SedeController(SedeBL sedeBL, IMapper mapper)
        {
            this.sedeBL = sedeBL;
            this.mapper = mapper;
        }

        #region Puntos de acceso

        /// <summary>
        ///     Consultar lista sede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        [HttpGet]
        [Route(nameof(SedeController.ConsultarListaSede))]
        public async Task<Respuesta<List<SedeDTO>>> ConsultarListaSede()
           => MapRespuestaListSedeDTO(await sedeBL.ConsultarListaSede());

        /// <summary>
        ///     Consultar sede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="sede">DTO sede</param>
        [HttpPost]
        [Route(nameof(SedeController.ConsultarSede))]
        public async Task<Respuesta<SedeDTO>> ConsultarSede([FromBody] SedeDTO sede)
        {
            if (EntidadValida(sede))
                return CrearRespuesta<SedeDTO>.Fallida(MensajeError());
            return MapRespuestaSedeDTO(await sedeBL.ConsultarSede(mapper.Map<SedeDTO, ISedeDTO>(sede)));
        }

        /// <summary>
        ///     Editar sede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="sede">DTO sede</param>
        [HttpPost]
        [Route(nameof(SedeController.EditarSede))]
        public async Task<Respuesta<EditarSedeDTO>> EditarSede([FromBody] EditarSedeDTO sede)
        {
            if (EntidadValida(sede))
                return CrearRespuesta<EditarSedeDTO>.Fallida(MensajeError());
            return MapRespuestaEditarSedeDTO(await sedeBL.EditarSede(mapper.Map<EditarSedeDTO, ISedeDTO>(sede)));
        }

        /// <summary>
        ///     Eliminar sede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="sede">DTO sede</param>
        [HttpPost]
        [Route(nameof(SedeController.EliminarSede))]
        public async Task<Respuesta<SedeDTO>> EliminarSede([FromBody] SedeDTO sede)
        {
            if (EntidadValida(sede))
                return CrearRespuesta<SedeDTO>.Fallida(MensajeError());
            return MapRespuestaSedeDTO(await sedeBL.EliminarSede(mapper.Map<SedeDTO, ISedeDTO>(sede)));
        }

        /// <summary>
        ///     Guardar sede.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="sede">DTO sede</param>
        [HttpPost]
        [Route(nameof(SedeController.GuardarSede))]
        public async Task<Respuesta<GuardarSedeDTO>> GuardarSede([FromBody] GuardarSedeDTO sede)
        {
            if (EntidadValida(sede))
                return CrearRespuesta<GuardarSedeDTO>.Fallida(MensajeError());
            return MapRespuestaGuardarSedeDTO(await sedeBL.GuardarSede(mapper.Map<GuardarSedeDTO, ISedeDTO>(sede)));
        }

        #endregion Puntos de acceso

        #region Metodos Privados

        private Respuesta<SedeDTO> MapRespuestaSedeDTO(Respuesta<ISedeDTO> sede)
            => mapper.Map<Respuesta<ISedeDTO>, Respuesta<SedeDTO>>(sede);

        private Respuesta<EditarSedeDTO> MapRespuestaEditarSedeDTO(Respuesta<ISedeDTO> sede)
            => mapper.Map<Respuesta<ISedeDTO>, Respuesta<EditarSedeDTO>>(sede);

        private Respuesta<GuardarSedeDTO> MapRespuestaGuardarSedeDTO(Respuesta<ISedeDTO> sede)
            => mapper.Map<Respuesta<ISedeDTO>, Respuesta<GuardarSedeDTO>>(sede);

        private Respuesta<List<SedeDTO>> MapRespuestaListSedeDTO(Respuesta<List<ISedeDTO>> sede)
            => mapper.Map<Respuesta<List<ISedeDTO>>, Respuesta<List<SedeDTO>>>(sede);

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