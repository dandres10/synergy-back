namespace API.CO.Entidades
{
    using Base.IC.DTO.Entidades;
    using System;

    public class PersonaCO : IPersonaDTO
    {
        public Guid Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool? Estado { get; set; }
    }
}