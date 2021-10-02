namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IPersonasedeAccion
    {
        Task<Respuesta<IPersonasedeDTO>> GuardarPersonasede(IPersonasedeDTO personasede);
        Task<Respuesta<IPersonasedeDTO>> ConsultarPersonasede(IPersonasedeDTO personasede);
        Task<Respuesta<IPersonasedeDTO>> EditarPersonasede(IPersonasedeDTO personasede);
        Task<Respuesta<List<IPersonasedeDTO>>> ConsultarListaPersonasede();
        Task<Respuesta<IPersonasedeDTO>> EliminarPersonasede(IPersonasedeDTO personasede);
    }
}
