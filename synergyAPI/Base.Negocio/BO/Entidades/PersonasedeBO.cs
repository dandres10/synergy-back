namespace Base.Negocio.BO.Entidades
{
    using Base.IC.DTO.Entidades;
    using System;

    public class PersonasedeBO : IPersonasedeDTO
    {
        public Guid? Persona { get; set; }
        public Guid? Sede { get; set; }
    }
}