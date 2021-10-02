namespace API.DTO.Entidades.Pais
{
    using Base.Transversal.Clases;
    using System;
    
    public class PaisDTO
    {
        [GuidRequerido]
        public Guid Id { get; set; }
    
        public string Nombre { get; set; }
    
        public bool Estado { get; set; }
    
        public string Sigla { get; set; }
    
        public DateTime FechaInicio { get; set; }
    
    }
}
