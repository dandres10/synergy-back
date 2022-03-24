using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto
{
    public partial class Rol
    {
        public Rol()
        {
            GrupoRols = new HashSet<GrupoRol>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<GrupoRol> GrupoRols { get; set; }
    }
}
