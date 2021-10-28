namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersonaempresaAccion
    {
        Task<Respuesta<IPersonaempresaDTO>> GuardarPersonaempresa(IPersonaempresaDTO personaempresa);

        Task<Respuesta<IPersonaempresaDTO>> ConsultarPersonaempresa(IPersonaempresaDTO personaempresa);

        Task<Respuesta<IPersonaempresaDTO>> EditarPersonaempresa(IPersonaempresaDTO personaempresa);

        Task<Respuesta<List<IPersonaempresaDTO>>> ConsultarListaPersonaempresa();

        Task<Respuesta<IPersonaempresaDTO>> EliminarPersonaempresa(IPersonaempresaDTO personaempresa);
    }
}