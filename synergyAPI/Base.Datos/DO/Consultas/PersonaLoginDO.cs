namespace Base.Datos.DO.Consultas
{
    using Base.IC.DTO.Consultas;
    using System;
    using System.Collections.Generic;

    public class PersonaInfoDO : IPersonaInfoDTO
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public List<string> NombreRoles { get; set; }
        public List<string> CodigoRoles { get; set; }
        public string Token { get; set; }
        public bool Estado { get ; set ; }
    }


    public class PersonaLoginDO : IPersonaLoginDTO
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
}