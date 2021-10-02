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

    public class PersonasedeDAL : AccesoComunDAL, IPersonasedeAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PersonasedeDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<IPersonasedeDTO>>> ConsultarListaPersonasede()
                => await EjecutarTransaccionAsync(async () =>
                   {
                       List<PersonaSede> personasede = await context.PersonaSedes.AsNoTracking().ToListAsync();
                       if (IsNull(personasede))
                           return CrearRespuesta<IPersonasedeDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IPersonasedeDTO>.ExitosaLista(MapListIPersonasedeDTO(personasede));
                   });

        public async Task<Respuesta<IPersonasedeDTO>> ConsultarPersonasede(IPersonasedeDTO personasede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaSede personasedeDO = MapPersonasede(personasede);
                       personasedeDO = await context.PersonaSedes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(personasedeDO.Id));
                       if (IsNull(personasedeDO))
                           return CrearRespuesta<IPersonasedeDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IPersonasedeDTO>.Exitosa(MapIPersonasedeDTO(personasedeDO), MensajesBaseEspanol.SuccessfulConsultation);
                   });

        public async Task<Respuesta<IPersonasedeDTO>> EditarPersonasede(IPersonasedeDTO personasede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaSede personasedeDO = MapPersonasede(personasede);
                       context.Entry(personasedeDO).State = EntityState.Modified;
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPersonasedeDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData);
                   });

        public async Task<Respuesta<IPersonasedeDTO>> EliminarPersonasede(IPersonasedeDTO personasede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaSede personasedeDO = MapPersonasede(personasede);
                       context.PersonaSedes.Remove(personasedeDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPersonasedeDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                   });

        public async Task<Respuesta<IPersonasedeDTO>> GuardarPersonasede(IPersonasedeDTO personasede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       PersonaSede personasedeDO = MapPersonasede(personasede);
                       context.PersonaSedes.Add(personasedeDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPersonasedeDTO>.Exitosa(null, MensajesBaseEspanol.CreateData);
                   });

        #region Metodos Privados

        private PersonaSede MapPersonasede(IPersonasedeDTO personasede)
            => mapper.Map<IPersonasedeDTO, PersonaSede>(personasede);

        private IPersonasedeDTO MapIPersonasedeDTO(PersonaSede personasede)
            => mapper.Map<PersonaSede, IPersonasedeDTO>(personasede);

        private List<IPersonasedeDTO> MapListIPersonasedeDTO(List<PersonaSede> personasede)
            => mapper.Map<List<PersonaSede>, List<IPersonasedeDTO>>(personasede);

        #endregion Metodos Privados
    }
}