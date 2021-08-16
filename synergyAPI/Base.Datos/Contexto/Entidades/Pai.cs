using System;
using System.Collections.Generic;

#nullable disable

namespace Base.Datos.Contexto.Entidades
{
    public partial class Pai
    {
        public Pai()
        {
            Empresas = new HashSet<Empresa>();
            Sedes = new HashSet<Sede>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public string Sigla { get; set; }
        public DateTime FechaInicio { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Sede> Sedes { get; set; }
    }
}
