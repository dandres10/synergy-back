using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto
{
    public partial class PersonaSede
    {
        public Guid Persona { get; set; }
        public Guid Sede { get; set; }
        public Guid Id { get; set; }

        public virtual Persona PersonaNavigation { get; set; }
        public virtual Sede SedeNavigation { get; set; }
    }
}
