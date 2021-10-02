namespace Base.IC.DTO.Entidades
{
    using System;
    public interface IRegistrotarjetaDTO
    {
        public Guid? Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public Guid? Empresa { get; set; }
        public string MesVigenciaTarjeta { get; set; }
        public string AnoVigenciaTarjeta { get; set; }
        public string CodigoCVV { get; set; }
    }
}
