using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto.Entidades
{
    public partial class PersonaEmpresa
    {
        public Guid Persona { get; set; }
        public Guid Empresa { get; set; }
        public Guid Id { get; set; }

        public virtual Empresa EmpresaNavigation { get; set; }
        public virtual Persona PersonaNavigation { get; set; }
    }
}
