namespace API.CO.Entidades.Persona
{
    using Base.Transversal.Clases;
    using System;

    public class PersonaDTO
    {
        [GuidRequerido]
        public Guid? Id { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool? Estado { get; set; }
    }
}