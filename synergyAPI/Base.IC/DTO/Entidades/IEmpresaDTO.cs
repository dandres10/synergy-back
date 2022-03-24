namespace Base.IC.DTO.Entidades
{
    using System;

    public interface IEmpresaDTO
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public DateTime? FechaReIntegro { get; set; }
        public bool? Estado { get; set; }
        public Guid? Pais { get; set; }
        public string Nit { get; set; }
        public int CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}