using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto
{
    public partial class RegistroTarjetum
    {
        public Guid Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public Guid Empresa { get; set; }
        public string MesVigenciaTarjeta { get; set; }
        public string AnoVigenciaTarjeta { get; set; }
        public string CodigoCvv { get; set; }

        public virtual Empresa EmpresaNavigation { get; set; }
    }
}
