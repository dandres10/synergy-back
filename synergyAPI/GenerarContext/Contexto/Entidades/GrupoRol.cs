using System;
using System.Collections.Generic;

#nullable disable

namespace Base.Datos.Contexto.Entidades
{
    public partial class GrupoRol
    {
        public Guid Id { get; set; }
        public Guid Persona { get; set; }
        public Guid Rol { get; set; }
        public bool? Estado { get; set; }

        public virtual Persona PersonaNavigation { get; set; }
        public virtual Rol RolNavigation { get; set; }
    }
}
