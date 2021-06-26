﻿namespace Base.IC.DTO.Entidades
{
    using System;

    public interface IPersonaDTO
    {
        public Guid? Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool Estado { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime? FechaIncial { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}