namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IPaisAccion
    {
        Task<Respuesta<IPaisDTO>> GuardarPais(IPaisDTO pais);
        Task<Respuesta<IPaisDTO>> ConsultarPais(IPaisDTO pais);
        Task<Respuesta<IPaisDTO>> EditarPais(IPaisDTO pais);
        Task<Respuesta<List<IPaisDTO>>> ConsultarListaPais();
        Task<Respuesta<IPaisDTO>> EliminarPais(IPaisDTO pais);
    }
}
