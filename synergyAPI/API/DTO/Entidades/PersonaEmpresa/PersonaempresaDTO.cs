namespace API.DTO.Entidades.Personaempresa
{
    using Base.Transversal.Clases;
    using System;
    
    public class PersonaempresaDTO
    {
        public Guid Persona { get; set; }
    
        public Guid Empresa { get; set; }
    
        [GuidRequerido]
        public Guid Id { get; set; }
    
    }
}
