namespace API.Controllers
{
    #region Importaciones
     
    
    using API.Configuracion;
    using API.DTO.Entidades.Persona;
    using API.DTO.Entidades.Personaempresa;
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
     
    public class PersonaEmpresaController : AccesoComun
    {
        private readonly PersonaempresaBL personaempresaBL;
        private readonly IMapper mapper;
          
        public PersonaEmpresaController(PersonaempresaBL personaempresaBL, IMapper mapper)
        {
            this.personaempresaBL = personaempresaBL;
            this.mapper = mapper;
        }
       
        #region Puntos de acceso
       
        /// <summary>
        ///     Consultar lista personaempresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        [HttpGet]
        [Route(nameof(PersonaEmpresaController.ConsultarListaPersonaempresa))]
   
        public async Task<Respuesta<List<PersonaempresaDTO>>> ConsultarListaPersonaempresa()
           => MapRespuestaListPersonaempresaDTO(await personaempresaBL.ConsultarListaPersonaempresa());
      
        /// <summary>
        ///     Consultar personaempresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personaempresa">DTO personaempresa</param>
        [HttpPost]
        [Route(nameof(PersonaEmpresaController.ConsultarPersonaempresa))]
    
        public async Task<Respuesta<PersonaempresaDTO>> ConsultarPersonaempresa([FromBody] PersonaempresaDTO personaempresa)
        {
            if (EntidadValida(personaempresa))
                return CrearRespuesta<PersonaempresaDTO>.Fallida(MensajeError());
            return MapRespuestaPersonaempresaDTO(await personaempresaBL.ConsultarPersonaempresa(mapper.Map<PersonaempresaDTO, IPersonaempresaDTO>(personaempresa)));
        }
       
        /// <summary>
        ///     Editar personaempresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personaempresa">DTO personaempresa</param>
        [HttpPost]
        [Route(nameof(PersonaEmpresaController.EditarPersonaempresa))]
       
        public async Task<Respuesta<EditarPersonaempresaDTO>> EditarPersonaempresa([FromBody] EditarPersonaempresaDTO personaempresa)
        {
            if (EntidadValida(personaempresa))
                return CrearRespuesta<EditarPersonaempresaDTO>.Fallida(MensajeError());
            return MapRespuestaEditarPersonaempresaDTO(await personaempresaBL.EditarPersonaempresa(mapper.Map<EditarPersonaempresaDTO, IPersonaempresaDTO>(personaempresa)));
        }
         
        /// <summary>
        ///     Eliminar personaempresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personaempresa">DTO personaempresa</param>
        [HttpPost]
        [Route(nameof(PersonaEmpresaController.EliminarPersonaempresa))]
       
        public async Task<Respuesta<PersonaempresaDTO>> EliminarPersonaempresa([FromBody] PersonaempresaDTO personaempresa)
        {
            if (EntidadValida(personaempresa))
                return CrearRespuesta<PersonaempresaDTO>.Fallida(MensajeError());
            return MapRespuestaPersonaempresaDTO(await personaempresaBL.EliminarPersonaempresa(mapper.Map<PersonaempresaDTO, IPersonaempresaDTO>(personaempresa)));
        }
     
        /// <summary>
        ///     Guardar personaempresa.
        /// </summary>
        /// <author>Generador Codigo 1.0.0</author>
        /// <param name="personaempresa">DTO personaempresa</param>
        [HttpPost]
        [Route(nameof(PersonaEmpresaController.GuardarPersonaempresa))]
       
        public async Task<Respuesta<GuardarPersonaempresaDTO>>  GuardarPersonaempresa([FromBody] GuardarPersonaempresaDTO personaempresa)
        {
            if (EntidadValida(personaempresa))
                return CrearRespuesta<GuardarPersonaempresaDTO>.Fallida(MensajeError());
            return MapRespuestaGuardarPersonaempresaDTO(await personaempresaBL.GuardarPersonaempresa(mapper.Map<GuardarPersonaempresaDTO, IPersonaempresaDTO>(personaempresa)));
        }
        
        #endregion Puntos de acceso
      
        #region Metodos Privados
       
        private Respuesta<PersonaempresaDTO> MapRespuestaPersonaempresaDTO(Respuesta<IPersonaempresaDTO> personaempresa)
            => mapper.Map<Respuesta<IPersonaempresaDTO>, Respuesta<PersonaempresaDTO>>(personaempresa);
       
        private Respuesta<EditarPersonaempresaDTO> MapRespuestaEditarPersonaempresaDTO(Respuesta<IPersonaempresaDTO> personaempresa)
            => mapper.Map<Respuesta<IPersonaempresaDTO>, Respuesta<EditarPersonaempresaDTO>>(personaempresa);
      
        private Respuesta<GuardarPersonaempresaDTO> MapRespuestaGuardarPersonaempresaDTO(Respuesta<IPersonaempresaDTO> personaempresa)
            => mapper.Map<Respuesta<IPersonaempresaDTO>, Respuesta<GuardarPersonaempresaDTO>>(personaempresa);
     
        private Respuesta<List<PersonaempresaDTO>> MapRespuestaListPersonaempresaDTO(Respuesta<List<IPersonaempresaDTO>> personaempresa)
            => mapper.Map<Respuesta<List<IPersonaempresaDTO>>, Respuesta<List<PersonaempresaDTO>>>(personaempresa);
     
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
