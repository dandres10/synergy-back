using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto.Entidades
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
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }

        public virtual Empresa EmpresaNavigation { get; set; }
        public virtual Pai PaisNavigation { get; set; }
        public virtual ICollection<PersonaSede> PersonaSedes { get; set; }
    }
}
