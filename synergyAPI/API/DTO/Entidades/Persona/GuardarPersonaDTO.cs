namespace API.DTO.Entidades.Persona
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GuardarPersonaDTO
    {
        public Guid? Id { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public bool? Estado { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Contrasena es requerido.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El campo FechaIncial es requerido.")]
        public DateTime FechaIncial { get; set; }

        public DateTime? FechaFinal { get; set; }
    }
}