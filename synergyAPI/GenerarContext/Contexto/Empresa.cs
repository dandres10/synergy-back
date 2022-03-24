using System;
using System.Collections.Generic;

#nullable disable

namespace GenerarContext.Contexto
{
    public partial class Empresa
    {
        public Empresa()
        {
            PersonaEmpresas = new HashSet<PersonaEmpresa>();
            RegistroTarjeta = new HashSet<RegistroTarjetum>();
            Sedes = new HashSet<Sede>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public DateTime? FechaReIntegro { get; set; }
        public bool Estado { get; set; }
        public Guid Pais { get; set; }
        public string Nit { get; set; }
        public int? CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual Pai PaisNavigation { get; set; }
        public virtual ICollection<PersonaEmpresa> PersonaEmpresas { get; set; }
        public virtual ICollection<RegistroTarjetum> RegistroTarjeta { get; set; }
        public virtual ICollection<Sede> Sedes { get; set; }
    }
}
