namespace API.DTO.Entidades.Personasede
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class GuardarPersonasedeDTO
    {
        [Required(ErrorMessage = "El campo Persona es requerido.")]
        public Guid Persona { get; set; }
    
        [Required(ErrorMessage = "El campo Sede es requerido.")]
        public Guid Sede { get; set; }
    
    }
}
