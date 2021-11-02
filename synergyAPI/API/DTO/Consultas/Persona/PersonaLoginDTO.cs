namespace API.DTO.Consultas
{
    using Base.IC.DTO.Consultas;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PersonaInfoDTO : IPersonaInfoDTO
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public List<string> NombreRoles { get; set; }
        public List<string> CodigoRoles { get; set; }
        public string Token { get; set; }
        public bool Estado { get ; set ; }
        public List<Guid> Empresa { get ; set ; }
    }

    public class PersonaLoginDTO : IPersonaLoginDTO
    {
        [Required(ErrorMessage = "El campo Correo es requerido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido.")]
        public string Contrasena { get; set; }
    }

    public class PersonaLoginTokenDTO : IPersonaLoginTokenDTO
    {
        public string Token { get; set; }
        public string Nombre { get ; set ; }
        public bool Estado { get ; set ; }
        public string Correo { get ; set ; }

        public List<Guid> Empresa { get; set; }
    }
}