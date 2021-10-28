namespace Base.Negocio.BO.Entidades
{
    using Base.IC.DTO.Entidades;
    using System;

    public class PersonaEmpresaBO : IPersonaempresaDTO
    {
        public Guid Persona { get; set; }
        public Guid Empresa { get; set; }
        public Guid Id { get; set; }
    }
}