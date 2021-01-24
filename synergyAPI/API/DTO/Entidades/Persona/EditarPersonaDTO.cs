namespace API.DTO.Entidades.Persona
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditarPersonaDTO
    {
        [GuidRequerido]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "El campo primer nombre es requerido. ")]
        public string PrimerNombre { get; set; }

        [Required(ErrorMessage = "El campo segundo nombre es requerido. ")]
        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "El campo primer apellido es requerido. ")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El campo segundo apellido es requerido. ")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El campo estado es requerido. ")]
        public bool? Estado { get; set; }
    }
}