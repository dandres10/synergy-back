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

    public class SedeDAL : AccesoComunDAL, ISedeAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public SedeDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<ISedeDTO>>> ConsultarListaSede()
                => await EjecutarTransaccionAsync(async () =>
                   {
                       List<Sede> sede = await context.Sedes.AsNoTracking().ToListAsync();
                       if (IsNull(sede))
                           return CrearRespuesta<ISedeDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<ISedeDTO>.ExitosaLista(MapListISedeDTO(sede));
                   });

        public async Task<Respuesta<ISedeDTO>> ConsultarSede(ISedeDTO sede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       Sede sedeDO = MapSede(sede);
                       sedeDO = await context.Sedes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(sedeDO.Id));
                       if (IsNull(sedeDO))
                           return CrearRespuesta<ISedeDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<ISedeDTO>.Exitosa(MapISedeDTO(sedeDO), MensajesBaseEspanol.SuccessfulConsultation);
                   });

        public async Task<Respuesta<ISedeDTO>> EditarSede(ISedeDTO sede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       Sede sedeDO = MapSede(sede);
                       context.Sedes.Update(sedeDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<ISedeDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData);
                   });

        public async Task<Respuesta<ISedeDTO>> EliminarSede(ISedeDTO sede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       Sede sedeDO = MapSede(sede);
                       context.Sedes.Remove(sedeDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<ISedeDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                   });

        public async Task<Respuesta<ISedeDTO>> GuardarSede(ISedeDTO sede)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       Sede sedeDO = MapSede(sede);
                       sedeDO.FechaInicial = DateTime.Now;
                       sedeDO.FechaFinal = null;
                       context.Sedes.Add(sedeDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<ISedeDTO>.Exitosa(null, MensajesBaseEspanol.CreateData);
                   });

        #region Metodos Privados

        private Sede MapSede(ISedeDTO sede)
            => mapper.Map<ISedeDTO, Sede>(sede);

        private ISedeDTO MapISedeDTO(Sede sede)
            => mapper.Map<Sede, ISedeDTO>(sede);

        private List<ISedeDTO> MapListISedeDTO(List<Sede> sede)
            => mapper.Map<List<Sede>, List<ISedeDTO>>(sede);

        #endregion Metodos Privados
    }
}