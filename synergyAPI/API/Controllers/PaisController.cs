namespace API.Controllers
{
    #region Importaciones

    using API.Configuracion;
    using API.DTO.Entidades.Pais;
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
    public class PaisController : AccesoComun
    {
        private readonly PaisBL paisBL;
        private readonly IMapper mapper;

        public PaisController(PaisBL paisBL, IMapper mapper)
        {
            this.paisBL = paisBL;
            this.mapper = mapper;
        }

        #region Puntos de acceso

        /// <summary>
        ///     Consultar lista pais.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        [HttpGet]
        [Route(nameof(PaisController.ConsultarListaPais))]
        public async Task<Respuesta<List<PaisDTO>>> ConsultarListaPais()
           => MapRespuestaListPaisDTO(await paisBL.ConsultarListaPais());

        /// <summary>
        ///     Consultar pais.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="pais">DTO pais</param>
        [HttpPost]
        [Route(nameof(PaisController.ConsultarPais))]
        public async Task<Respuesta<PaisDTO>> ConsultarPais([FromBody] PaisDTO pais)
        {
            if (EntidadValida(pais))
                return CrearRespuesta<PaisDTO>.Fallida(MensajeError());
            return MapRespuestaPaisDTO(await paisBL.ConsultarPais(mapper.Map<PaisDTO, IPaisDTO>(pais)));
        }

        /// <summary>
        ///     Editar pais.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="pais">DTO pais</param>
        [HttpPost]
        [Route(nameof(PaisController.EditarPais))]
        public async Task<Respuesta<EditarPaisDTO>> EditarPais([FromBody] EditarPaisDTO pais)
        {
            if (EntidadValida(pais))
                return CrearRespuesta<EditarPaisDTO>.Fallida(MensajeError());
            return MapRespuestaEditarPaisDTO(await paisBL.EditarPais(mapper.Map<EditarPaisDTO, IPaisDTO>(pais)));
        }

        /// <summary>
        ///     Eliminar pais.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="pais">DTO pais</param>
        [HttpPost]
        [Route(nameof(PaisController.EliminarPais))]
        public async Task<Respuesta<PaisDTO>> EliminarPais([FromBody] PaisDTO pais)
        {
            if (EntidadValida(pais))
                return CrearRespuesta<PaisDTO>.Fallida(MensajeError());
            return MapRespuestaPaisDTO(await paisBL.EliminarPais(mapper.Map<PaisDTO, IPaisDTO>(pais)));
        }

        /// <summary>
        ///     Guardar pais.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="pais">DTO pais</param>
        [HttpPost]
        [Route(nameof(PaisController.GuardarPais))]
        public async Task<Respuesta<GuardarPaisDTO>> GuardarPais([FromBody] GuardarPaisDTO pais)
        {
            if (EntidadValida(pais))
                return CrearRespuesta<GuardarPaisDTO>.Fallida(MensajeError());
            return MapRespuestaGuardarPaisDTO(await paisBL.GuardarPais(mapper.Map<GuardarPaisDTO, IPaisDTO>(pais)));
        }

        #endregion Puntos de acceso

        #region Metodos Privados

        private Respuesta<PaisDTO> MapRespuestaPaisDTO(Respuesta<IPaisDTO> pais)
            => mapper.Map<Respuesta<IPaisDTO>, Respuesta<PaisDTO>>(pais);

        private Respuesta<EditarPaisDTO> MapRespuestaEditarPaisDTO(Respuesta<IPaisDTO> pais)
            => mapper.Map<Respuesta<IPaisDTO>, Respuesta<EditarPaisDTO>>(pais);

        private Respuesta<GuardarPaisDTO> MapRespuestaGuardarPaisDTO(Respuesta<IPaisDTO> pais)
            => mapper.Map<Respuesta<IPaisDTO>, Respuesta<GuardarPaisDTO>>(pais);

        private Respuesta<List<PaisDTO>> MapRespuestaListPaisDTO(Respuesta<List<IPaisDTO>> pais)
            => mapper.Map<Respuesta<List<IPaisDTO>>, Respuesta<List<PaisDTO>>>(pais);

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