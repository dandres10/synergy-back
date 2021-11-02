namespace API.DTO.Entidades.Sede
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GuardarSedeDTO
    {
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Estado es requerido.")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El campo Sigla es requerido.")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "El campo ColorBox es requerido.")]
        public string ColorBox { get; set; }

        [Required(ErrorMessage = "El campo Empresa es requerido.")]
        public Guid Empresa { get; set; }

        [Required(ErrorMessage = "El campo FechaInicial es requerido.")]
        public DateTime FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; }

        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo Pais es requerido.")]
        public Guid Pais { get; set; }

        [Required(ErrorMessage = "El campo Telefono 1 es requerido.")]
        public string Telefono1 { get; set; }

        public string Telefono2 { get; set; }

        [Required(ErrorMessage = "El campo Dirección es requerido.")]
        public string Direccion { get; set; }
    }
}