namespace API.DTO.Entidades.Personaempresa
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class EditarPersonaempresaDTO
    {
        [Required(ErrorMessage = "El campo Persona es requerido.")]
        public Guid Persona { get; set; }
    
        [Required(ErrorMessage = "El campo Empresa es requerido.")]
        public Guid Empresa { get; set; }
    
        [GuidRequerido]
        public Guid Id { get; set; }
    
    }
}
