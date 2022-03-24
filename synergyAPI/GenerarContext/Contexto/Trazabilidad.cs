using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto
{
    public partial class Trazabilidad
    {
        public Guid Id { get; set; }
        public string NombreMetodo { get; set; }
        public string Capa { get; set; }
        public string Error { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
