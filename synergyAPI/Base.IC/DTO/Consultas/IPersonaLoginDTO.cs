namespace Base.IC.DTO.Consultas
{
    using System;
    using System.Collections.Generic;

    public interface IPersonaInfoDTO
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        public bool Estado { get; set; }
        public string Token { get; set; }
        public List<string> NombreRoles { get; set; }
        public List<string> CodigoRoles { get; set; }
    }

    public interface IPersonaLoginDTO
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

    public interface IPersonaLoginTokenDTO
    {
        public string Token { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public string Correo { get; set; }
    }
}