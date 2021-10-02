namespace API.DTO.Entidades.Registrotarjeta
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditarRegistrotarjetaDTO
    {
        [GuidRequerido]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo NumeroDocumento es requerido.")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El campo NombreTitular es requerido.")]
        public string NombreTitular { get; set; }

        [Required(ErrorMessage = "El campo NumeroTarjeta es requerido.")]
        public string NumeroTarjeta { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFinal { get; set; }

        [Required(ErrorMessage = "El campo Empresa es requerido.")]
        public Guid Empresa { get; set; }

        [Required(ErrorMessage = "El campo MesVigenciaTarjeta es requerido.")]
        public string MesVigenciaTarjeta { get; set; }

        [Required(ErrorMessage = "El campo AnoVigenciaTarjeta es requerido.")]
        public string AnoVigenciaTarjeta { get; set; }

        [Required(ErrorMessage = "El campo CodigoCVV es requerido.")]
        public string CodigoCVV { get; set; }
    }
}