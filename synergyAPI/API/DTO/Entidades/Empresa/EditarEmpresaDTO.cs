namespace API.DTO.Entidades.Empresa
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditarEmpresaDTO
    { 
        [GuidRequerido]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Nit es requerido.")]
        public string Nit { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Celular es requerido.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido.")]
        public string Direccion { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; }

        public DateTime? FechaReIntegro { get; set; }

        [Required(ErrorMessage = "El campo Estado es requerido.")]
        public bool Estado { get; set; }

        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo Pais es requerido.")]
        public Guid Pais { get; set; }
    }
}