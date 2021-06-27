namespace Base.Negocio.BO.Consultas
{
    using Base.IC.DTO.Consultas;
    using System;
    using System.Collections.Generic;

    public class PersonaInfoBO : IPersonaInfoDTO
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public List<string> NombreRoles { get; set; }
        public List<string> CodigoRoles { get; set; }
        public string Token { get; set; }
    }

    public class PersonaLoginBO : IPersonaLoginDTO
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

    public class PersonaLoginTokenBO : IPersonaLoginTokenDTO
    {
        public string Token { get; set; }
    }
}