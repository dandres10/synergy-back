namespace API.Controllers
{
    #region Importaciones

    using API.Configuracion;
    using API.DTO.Entidades.Empresa;
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
    public class EmpresaController : AccesoComun
    {
        private readonly EmpresaBL empresaBL;
        private readonly IMapper mapper;

        public EmpresaController(EmpresaBL empresaBL, IMapper mapper)
        {
            this.empresaBL = empresaBL;
            this.mapper = mapper;
        }

        #region Puntos de acceso

        /// <summary>
        ///     Consultar lista empresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        [HttpGet]
        [Route(nameof(EmpresaController.ConsultarListaEmpresa))]
        public async Task<Respuesta<List<EmpresaDTO>>> ConsultarListaEmpresa()
           => MapRespuestaListEmpresaDTO(await empresaBL.ConsultarListaEmpresa());

        /// <summary>
        ///     Consultar empresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="empresa">DTO empresa</param>
        [HttpPost]
        [Route(nameof(EmpresaController.ConsultarEmpresa))]
        public async Task<Respuesta<EmpresaDTO>> ConsultarEmpresa([FromBody] EmpresaDTO empresa)
        {
            if (EntidadValida(empresa))
                return CrearRespuesta<EmpresaDTO>.Fallida(MensajeError());
            return MapRespuestaEmpresaDTO(await empresaBL.ConsultarEmpresa(mapper.Map<EmpresaDTO, IEmpresaDTO>(empresa)));
        }

        /// <summary>
        ///     Editar empresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="empresa">DTO empresa</param>
        [HttpPost]
        [Route(nameof(EmpresaController.EditarEmpresa))]
        public async Task<Respuesta<EditarEmpresaDTO>> EditarEmpresa([FromBody] EditarEmpresaDTO empresa)
        {
            if (EntidadValida(empresa))
                return CrearRespuesta<EditarEmpresaDTO>.Fallida(MensajeError());
            return MapRespuestaEditarEmpresaDTO(await empresaBL.EditarEmpresa(mapper.Map<EditarEmpresaDTO, IEmpresaDTO>(empresa)));
        }

        /// <summary>
        ///     Eliminar empresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="empresa">DTO empresa</param>
        [HttpPost]
        [Route(nameof(EmpresaController.EliminarEmpresa))]
        public async Task<Respuesta<EmpresaDTO>> EliminarEmpresa([FromBody] EmpresaDTO empresa)
        {
            if (EntidadValida(empresa))
                return CrearRespuesta<EmpresaDTO>.Fallida(MensajeError());
            return MapRespuestaEmpresaDTO(await empresaBL.EliminarEmpresa(mapper.Map<EmpresaDTO, IEmpresaDTO>(empresa)));
        }

        /// <summary>
        ///     Guardar empresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="empresa">DTO empresa</param>
        [HttpPost]
        [Route(nameof(EmpresaController.GuardarEmpresa))]
        public async Task<Respuesta<GuardarEmpresaDTO>> GuardarEmpresa([FromBody] GuardarEmpresaDTO empresa)
        {
            if (EntidadValida(empresa))
                return CrearRespuesta<GuardarEmpresaDTO>.Fallida(MensajeError());
            return MapRespuestaGuardarEmpresaDTO(await empresaBL.GuardarEmpresa(mapper.Map<GuardarEmpresaDTO, IEmpresaDTO>(empresa)));
        }

        #endregion Puntos de acceso

        #region Metodos Privados

        private Respuesta<EmpresaDTO> MapRespuestaEmpresaDTO(Respuesta<IEmpresaDTO> empresa)
            => mapper.Map<Respuesta<IEmpresaDTO>, Respuesta<EmpresaDTO>>(empresa);

        private Respuesta<EditarEmpresaDTO> MapRespuestaEditarEmpresaDTO(Respuesta<IEmpresaDTO> empresa)
            => mapper.Map<Respuesta<IEmpresaDTO>, Respuesta<EditarEmpresaDTO>>(empresa);

        private Respuesta<GuardarEmpresaDTO> MapRespuestaGuardarEmpresaDTO(Respuesta<IEmpresaDTO> empresa)
            => mapper.Map<Respuesta<IEmpresaDTO>, Respuesta<GuardarEmpresaDTO>>(empresa);

        private Respuesta<List<EmpresaDTO>> MapRespuestaListEmpresaDTO(Respuesta<List<IEmpresaDTO>> empresa)
            => mapper.Map<Respuesta<List<IEmpresaDTO>>, Respuesta<List<EmpresaDTO>>>(empresa);

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