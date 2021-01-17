namespace API.CO.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PersonaCO : IPersonaDTO
    {
        [GuidRequerido]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool? Estado { get; set; }
    }
}