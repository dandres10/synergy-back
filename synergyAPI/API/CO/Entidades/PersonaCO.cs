namespace API.CO.Entidades
{
    using Base.Transversal.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PersonaCO
    {
        [GuidRequerido]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "El campo primer nombre es requerido. ")]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool? Estado { get; set; }
    }
}