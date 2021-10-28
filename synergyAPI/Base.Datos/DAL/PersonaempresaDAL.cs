namespace Base.Datos.DAL
{
    #region Importaciones

    using AutoMapper;
    using Base.Datos.Configuracion;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;
    using Base.Transversal.Mensajes;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion Importaciones

    public class PersonaempresaDAL : AccesoComunDAL, IPersonaempresaAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PersonaempresaDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<IPersonaempresaDTO>>> ConsultarListaPersonaempresa()
                => await EjecutarTransaccionAsync(async () =>
                   {
                       List<PersonaEmpresa> personaempresa = await context.PersonaEmpresas.AsNoTracking().ToListAsync();
                       if (IsNull(personaempresa))
                           return CrearRespuesta<IPersonaempresaDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IPersonaempresaDTO>.ExitosaLista(MapListIPersonaempresaDTO(personaempresa));
                   });

        public async Task<Respuesta<IPersonaempresaDTO>> ConsultarPersonaempresa(IPersonaempresaDTO personaempresa)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaEmpresa personaempresaDO = MapPersonaempresa(personaempresa);
                       personaempresaDO = await context.PersonaEmpresas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(personaempresaDO.Id));
                       if (IsNull(personaempresaDO))
                           return CrearRespuesta<IPersonaempresaDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IPersonaempresaDTO>.Exitosa(MapIPersonaempresaDTO(personaempresaDO), MensajesBaseEspanol.SuccessfulConsultation);
                   });

        public async Task<Respuesta<IPersonaempresaDTO>> EditarPersonaempresa(IPersonaempresaDTO personaempresa)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaEmpresa personaempresaDO = MapPersonaempresa(personaempresa);
                       context.Entry(personaempresaDO).State = EntityState.Modified;
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPersonaempresaDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData);
                   });

        public async Task<Respuesta<IPersonaempresaDTO>> EliminarPersonaempresa(IPersonaempresaDTO personaempresa)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaEmpresa personaempresaDO = MapPersonaempresa(personaempresa);
                       context.PersonaEmpresas.Remove(personaempresaDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPersonaempresaDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                   });

        public async Task<Respuesta<IPersonaempresaDTO>> GuardarPersonaempresa(IPersonaempresaDTO personaempresa)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaEmpresa personaempresaDO = MapPersonaempresa(personaempresa);
                       personaempresaDO.Id = Guid.NewGuid();
                       context.PersonaEmpresas.Add(personaempresaDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPersonaempresaDTO>.Exitosa(MapIPersonaempresaDTO(personaempresaDO), MensajesBaseEspanol.CreateData);
                   });

        #region Metodos Privados

        private PersonaEmpresa MapPersonaempresa(IPersonaempresaDTO personaempresa)
            => mapper.Map<IPersonaempresaDTO, PersonaEmpresa>(personaempresa);

        private IPersonaempresaDTO MapIPersonaempresaDTO(PersonaEmpresa personaempresa)
            => mapper.Map<PersonaEmpresa, IPersonaempresaDTO>(personaempresa);

        private List<IPersonaempresaDTO> MapListIPersonaempresaDTO(List<PersonaEmpresa> personaempresa)
            => mapper.Map<List<PersonaEmpresa>, List<IPersonaempresaDTO>>(personaempresa);

        #endregion Metodos Privados
    }
}