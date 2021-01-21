namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersonaAccion
    {
        Task<Respuesta<IPersonaDTO>> GuardarPersona(IPersonaDTO persona);

        Task<Respuesta<IPersonaDTO>> ConsultarPersona(IPersonaDTO persona);

        Task<Respuesta<IPersonaDTO>> EditarPersona(IPersonaDTO persona);

        Task<Respuesta<List<IPersonaDTO>>> ConsultarListaPersona();

        Task<Respuesta<IPersonaDTO>> EliminarPersona(IPersonaDTO persona);
    }
}