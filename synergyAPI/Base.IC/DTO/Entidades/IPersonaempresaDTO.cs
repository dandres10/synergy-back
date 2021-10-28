namespace Base.IC.DTO.Entidades
{
    using System;
    public interface IPersonaempresaDTO
    {
        public Guid Persona { get; set; }
        public Guid Empresa { get; set; }
        public Guid Id { get; set; }
    }
}
