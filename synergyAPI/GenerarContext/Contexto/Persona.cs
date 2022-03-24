using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto
{
    public partial class Persona
    {
        public Persona()
        {
            GrupoRols = new HashSet<GrupoRol>();
            PersonaEmpresas = new HashSet<PersonaEmpresa>();
            PersonaSedes = new HashSet<PersonaSede>();
        }

        public Guid Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool? Estado { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaIncial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string CelularPersona { get; set; }

        public virtual ICollection<GrupoRol> GrupoRols { get; set; }
        public virtual ICollection<PersonaEmpresa> PersonaEmpresas { get; set; }
        public virtual ICollection<PersonaSede> PersonaSedes { get; set; }
    }
}
