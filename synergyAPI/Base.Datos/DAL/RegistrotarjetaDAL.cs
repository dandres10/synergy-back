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

    public class RegistrotarjetaDAL : AccesoComunDAL, IRegistrotarjetaAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public RegistrotarjetaDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<IRegistrotarjetaDTO>>> ConsultarListaRegistrotarjeta()
                => await EjecutarTransaccionAsync<List<IRegistrotarjetaDTO>>(async () =>
                   {
                       List<RegistroTarjetum> registrotarjeta = await context.RegistroTarjeta.AsNoTracking().ToListAsync();
                       if (IsNull(registrotarjeta))
                           return CrearRespuesta<IRegistrotarjetaDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IRegistrotarjetaDTO>.ExitosaLista(MapListIRegistrotarjetaDTO(registrotarjeta));
                   });

        public async Task<Respuesta<IRegistrotarjetaDTO>> ConsultarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
                => await EjecutarTransaccionAsync<IRegistrotarjetaDTO>(async () =>
                   {
                       RegistroTarjetum registrotarjetaDO = MapRegistrotarjeta(registrotarjeta);
                       registrotarjetaDO = await context.RegistroTarjeta.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(registrotarjetaDO.Id));
                       if (IsNull(registrotarjetaDO))
                           return CrearRespuesta<IRegistrotarjetaDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IRegistrotarjetaDTO>.Exitosa(MapIRegistrotarjetaDTO(registrotarjetaDO), MensajesBaseEspanol.SuccessfulConsultation);
                   });

        public async Task<Respuesta<IRegistrotarjetaDTO>> EditarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
                => await EjecutarTransaccionAsync<IRegistrotarjetaDTO>(async () =>
                   {
                       RegistroTarjetum registrotarjetaDO = MapRegistrotarjeta(registrotarjeta);
                       context.Entry(registrotarjetaDO).State = EntityState.Modified;
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IRegistrotarjetaDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData);
                   });

        public async Task<Respuesta<IRegistrotarjetaDTO>> EliminarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
                => await EjecutarTransaccionAsync<IRegistrotarjetaDTO>(async () =>
                   {
                       RegistroTarjetum registrotarjetaDO = MapRegistrotarjeta(registrotarjeta);
                       context.RegistroTarjeta.Remove(registrotarjetaDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IRegistrotarjetaDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                   });

        public async Task<Respuesta<IRegistrotarjetaDTO>> GuardarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
                => await EjecutarTransaccionAsync<IRegistrotarjetaDTO>(async () =>
                   {
                       RegistroTarjetum registrotarjetaDO = MapRegistrotarjeta(registrotarjeta);
                       registrotarjetaDO.FechaInicio = DateTime.Now;
                       registrotarjetaDO.FechaFinal = null;
                       context.RegistroTarjeta.Add(registrotarjetaDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IRegistrotarjetaDTO>.Exitosa(null, MensajesBaseEspanol.CreateData);
                   });

        #region Metodos Privados

        private RegistroTarjetum MapRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
            => mapper.Map<IRegistrotarjetaDTO, RegistroTarjetum>(registrotarjeta);

        private IRegistrotarjetaDTO MapIRegistrotarjetaDTO(RegistroTarjetum registrotarjeta)
            => mapper.Map<RegistroTarjetum, IRegistrotarjetaDTO>(registrotarjeta);

        private List<IRegistrotarjetaDTO> MapListIRegistrotarjetaDTO(List<RegistroTarjetum> registrotarjeta)
            => mapper.Map<List<RegistroTarjetum>, List<IRegistrotarjetaDTO>>(registrotarjeta);

        #endregion Metodos Privados
    }
}