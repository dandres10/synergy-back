namespace API.DTO.Entidades.Pais
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class GuardarPaisDTO
    {
        
    
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }
    
        [Required(ErrorMessage = "El campo Estado es requerido.")]
        public bool Estado { get; set; }
    
        [Required(ErrorMessage = "El campo Sigla es requerido.")]
        public string Sigla { get; set; }
    
        [Required(ErrorMessage = "El campo FechaInicio es requerido.")]
        public DateTime FechaInicio { get; set; }
    
    }
}
