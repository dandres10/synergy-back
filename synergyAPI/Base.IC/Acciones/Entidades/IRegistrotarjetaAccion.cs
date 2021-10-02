namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IRegistrotarjetaAccion
    {
        Task<Respuesta<IRegistrotarjetaDTO>> GuardarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta);
        Task<Respuesta<IRegistrotarjetaDTO>> ConsultarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta);
        Task<Respuesta<IRegistrotarjetaDTO>> EditarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta);
        Task<Respuesta<List<IRegistrotarjetaDTO>>> ConsultarListaRegistrotarjeta();
        Task<Respuesta<IRegistrotarjetaDTO>> EliminarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta);
    }
}
