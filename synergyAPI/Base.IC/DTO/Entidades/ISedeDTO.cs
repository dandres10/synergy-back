namespace Base.IC.DTO.Entidades
{
    using System;

    public interface ISedeDTO
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; }
        public string Sigla { get; set; }
        public string ColorBox { get; set; }
        public Guid? Empresa { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string CodigoPostal { get; set; }
        public Guid Pais { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
    }
}