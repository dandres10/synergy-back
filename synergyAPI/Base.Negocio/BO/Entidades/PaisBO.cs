namespace Base.Negocio.BO.Entidades
{
    using Base.IC.DTO.Entidades;
    using System;

    public class PaisBO : IPaisDTO
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; }
        public string Sigla { get; set; }
        public DateTime? FechaInicio { get; set; }
    }
}