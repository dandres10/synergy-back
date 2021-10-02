namespace Base.IC.DTO.Entidades
{
    using System;
    public interface IPaisDTO
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; }
        public string Sigla { get; set; }
        public DateTime? FechaInicio { get; set; }
    }
}
