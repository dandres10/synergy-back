namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IEmpresaAccion
    {
        Task<Respuesta<IEmpresaDTO>> GuardarEmpresa(IEmpresaDTO empresa);
        Task<Respuesta<IEmpresaDTO>> ConsultarEmpresa(IEmpresaDTO empresa);
        Task<Respuesta<IEmpresaDTO>> EditarEmpresa(IEmpresaDTO empresa);
        Task<Respuesta<List<IEmpresaDTO>>> ConsultarListaEmpresa();
        Task<Respuesta<IEmpresaDTO>> EliminarEmpresa(IEmpresaDTO empresa);
    }
}
