using System;
using System.Collections.Generic;

#nullable disable

namespace Base.Datos.Contexto.Entidades
{
    public partial class Sede
    {
        public Sede()
        {
            PersonaSedes = new HashSet<PersonaSede>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public string Sigla { get; set; }
        public string ColorBox { get; set; }
        public Guid Empresa { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string CodigoPostal { get; set; }
        public Guid Pais { get; set; }

        public virtual Empresa EmpresaNavigation { get; set; }
        public virtual Pai PaisNavigation { get; set; }
        public virtual ICollection<PersonaSede> PersonaSedes { get; set; }
    }
}
