namespace Base.Negocio.BO.Entidades
{
    using Base.IC.DTO.Entidades;
    using System;

    public class PersonaBO : IPersonaDTO
    {
        public Guid? Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaIncial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Correo { get ; set ; }
        public string Contrasena { get ; set ; }
        public string CelularPersona { get ; set ; }
    }
}