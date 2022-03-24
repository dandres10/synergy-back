namespace API.DTO.Entidades.Empresa
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class GuardarEmpresaDTO
    {
        [GuidRequerido]
        public Guid Id { get; set; }
    
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }
    
        [Required(ErrorMessage = "El campo Celular es requerido.")]
        public string Celular { get; set; }
    
        [Required(ErrorMessage = "El campo FechaInicial es requerido.")]
        public DateTime FechaInicial { get; set; }
    
        public DateTime? FechaFinal { get; set; }
    
        public DateTime? FechaReIntegro { get; set; }
    
        [Required(ErrorMessage = "El campo Estado es requerido.")]
        public bool Estado { get; set; }
    
        [Required(ErrorMessage = "El campo Pais es requerido.")]
        public Guid Pais { get; set; }
    
        public string Nit { get; set; }
    
        public int? CodigoPostal { get; set; }
    
        public string Direccion { get; set; }
    
        public string Telefono { get; set; }
    
    }
}
