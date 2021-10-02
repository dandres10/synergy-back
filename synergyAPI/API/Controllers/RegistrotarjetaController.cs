namespace API.Controllers
{
    #region Importaciones

    using API.Configuracion;
    using API.DTO.Entidades.Registrotarjeta;
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
    public class RegistroTarjetaController : AccesoComun
    {
        private readonly RegistrotarjetaBL registrotarjetaBL;
        private readonly IMapper mapper;

        public RegistroTarjetaController(RegistrotarjetaBL registrotarjetaBL, IMapper mapper)
        {
            this.registrotarjetaBL = registrotarjetaBL;
            this.mapper = mapper;
        }

        #region Puntos de acceso

        /// <summary>
        ///     Consultar lista registrotarjeta.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        [HttpGet]
        [Route(nameof(RegistroTarjetaController.ConsultarListaRegistrotarjeta))]
        public async Task<Respuesta<List<RegistrotarjetaDTO>>> ConsultarListaRegistrotarjeta()
           => MapRespuestaListRegistrotarjetaDTO(await registrotarjetaBL.ConsultarListaRegistrotarjeta());

        /// <summary>
        ///     Consultar registrotarjeta.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="registrotarjeta">DTO registrotarjeta</param>
        [HttpPost]
        [Route(nameof(RegistroTarjetaController.ConsultarRegistrotarjeta))]
        public async Task<Respuesta<RegistrotarjetaDTO>> ConsultarRegistrotarjeta([FromBody] RegistrotarjetaDTO registrotarjeta)
        {
            if (EntidadValida(registrotarjeta))
                return CrearRespuesta<RegistrotarjetaDTO>.Fallida(MensajeError());
            return MapRespuestaRegistrotarjetaDTO(await registrotarjetaBL.ConsultarRegistrotarjeta(mapper.Map<RegistrotarjetaDTO, IRegistrotarjetaDTO>(registrotarjeta)));
        }

        /// <summary>
        ///     Editar registrotarjeta.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="registrotarjeta">DTO registrotarjeta</param>
        [HttpPost]
        [Route(nameof(RegistroTarjetaController.EditarRegistrotarjeta))]
        public async Task<Respuesta<EditarRegistrotarjetaDTO>> EditarRegistrotarjeta([FromBody] EditarRegistrotarjetaDTO registrotarjeta)
        {
            if (EntidadValida(registrotarjeta))
                return CrearRespuesta<EditarRegistrotarjetaDTO>.Fallida(MensajeError());
            return MapRespuestaEditarRegistrotarjetaDTO(await registrotarjetaBL.EditarRegistrotarjeta(mapper.Map<EditarRegistrotarjetaDTO, IRegistrotarjetaDTO>(registrotarjeta)));
        }

        /// <summary>
        ///     Eliminar registrotarjeta.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="registrotarjeta">DTO registrotarjeta</param>
        [HttpPost]
        [Route(nameof(RegistroTarjetaController.EliminarRegistrotarjeta))]
        public async Task<Respuesta<RegistrotarjetaDTO>> EliminarRegistrotarjeta([FromBody] RegistrotarjetaDTO registrotarjeta)
        {
            if (EntidadValida(registrotarjeta))
                return CrearRespuesta<RegistrotarjetaDTO>.Fallida(MensajeError());
            return MapRespuestaRegistrotarjetaDTO(await registrotarjetaBL.EliminarRegistrotarjeta(mapper.Map<RegistrotarjetaDTO, IRegistrotarjetaDTO>(registrotarjeta)));
        }

        /// <summary>
        ///     Guardar registrotarjeta.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="registrotarjeta">DTO registrotarjeta</param>
        [HttpPost]
        [Route(nameof(RegistroTarjetaController.GuardarRegistrotarjeta))]
        public async Task<Respuesta<GuardarRegistrotarjetaDTO>> GuardarRegistrotarjeta([FromBody] GuardarRegistrotarjetaDTO registrotarjeta)
        {
            if (EntidadValida(registrotarjeta))
                return CrearRespuesta<GuardarRegistrotarjetaDTO>.Fallida(MensajeError());
            return MapRespuestaGuardarRegistrotarjetaDTO(await registrotarjetaBL.GuardarRegistrotarjeta(mapper.Map<GuardarRegistrotarjetaDTO, IRegistrotarjetaDTO>(registrotarjeta)));
        }

        #endregion Puntos de acceso

        #region Metodos Privados

        private Respuesta<RegistrotarjetaDTO> MapRespuestaRegistrotarjetaDTO(Respuesta<IRegistrotarjetaDTO> registrotarjeta)
            => mapper.Map<Respuesta<IRegistrotarjetaDTO>, Respuesta<RegistrotarjetaDTO>>(registrotarjeta);

        private Respuesta<EditarRegistrotarjetaDTO> MapRespuestaEditarRegistrotarjetaDTO(Respuesta<IRegistrotarjetaDTO> registrotarjeta)
            => mapper.Map<Respuesta<IRegistrotarjetaDTO>, Respuesta<EditarRegistrotarjetaDTO>>(registrotarjeta);

        private Respuesta<GuardarRegistrotarjetaDTO> MapRespuestaGuardarRegistrotarjetaDTO(Respuesta<IRegistrotarjetaDTO> registrotarjeta)
            => mapper.Map<Respuesta<IRegistrotarjetaDTO>, Respuesta<GuardarRegistrotarjetaDTO>>(registrotarjeta);

        private Respuesta<List<RegistrotarjetaDTO>> MapRespuestaListRegistrotarjetaDTO(Respuesta<List<IRegistrotarjetaDTO>> registrotarjeta)
            => mapper.Map<Respuesta<List<IRegistrotarjetaDTO>>, Respuesta<List<RegistrotarjetaDTO>>>(registrotarjeta);

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