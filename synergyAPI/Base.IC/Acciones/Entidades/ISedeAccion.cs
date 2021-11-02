namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ISedeAccion
    {
        Task<Respuesta<ISedeDTO>> GuardarSede(ISedeDTO sede);
        Task<Respuesta<ISedeDTO>> ConsultarSede(ISedeDTO sede);
        Task<Respuesta<ISedeDTO>> EditarSede(ISedeDTO sede);
        Task<Respuesta<List<ISedeDTO>>> ConsultarListaSede(Guid Empresa);
        Task<Respuesta<ISedeDTO>> EliminarSede(ISedeDTO sede);
    }
}
