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

    public class PaisDAL : AccesoComunDAL, IPaisAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PaisDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<IPaisDTO>>> ConsultarListaPais()
                => await EjecutarTransaccionAsync<List<IPaisDTO>>(async () =>
                   {
                       List<Pai> pais = await context.Pais.AsNoTracking().ToListAsync();
                       if (IsNull(pais))
                           return CrearRespuesta<IPaisDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IPaisDTO>.ExitosaLista(MapListIPaisDTO(pais));
                   });

        public async Task<Respuesta<IPaisDTO>> ConsultarPais(IPaisDTO pais)
                => await EjecutarTransaccionAsync<IPaisDTO>(async () =>
                   {
                       Pai paisDO = MapPais(pais);
                       paisDO = await context.Pais.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(paisDO.Id));
                       if (IsNull(paisDO))
                           return CrearRespuesta<IPaisDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IPaisDTO>.Exitosa(MapIPaisDTO(paisDO), MensajesBaseEspanol.SuccessfulConsultation);
                   });

        public async Task<Respuesta<IPaisDTO>> EditarPais(IPaisDTO pais)
                => await EjecutarTransaccionAsync<IPaisDTO>(async () =>
                   {
                       Pai paisDO = MapPais(pais);
                       context.Pais.Update(paisDO).Property(p => p.FechaInicio).IsModified = false;
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPaisDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData); 
                   });

        public async Task<Respuesta<IPaisDTO>> EliminarPais(IPaisDTO pais)
                => await EjecutarTransaccionAsync<IPaisDTO>(async () =>
                   {
                       Pai paisDO = MapPais(pais);
                       context.Pais.Remove(paisDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPaisDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                   });

        public async Task<Respuesta<IPaisDTO>> GuardarPais(IPaisDTO pais)
                => await EjecutarTransaccionAsync<IPaisDTO>(async () =>
                   {
                       Pai paisDO = MapPais(pais);
                       paisDO.Id = Guid.NewGuid();
                       context.Pais.Add(paisDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IPaisDTO>.Exitosa(null, MensajesBaseEspanol.CreateData);
                   });

        #region Metodos Privados

        private Pai MapPais(IPaisDTO pais)
            => mapper.Map<IPaisDTO, Pai>(pais);

        private IPaisDTO MapIPaisDTO(Pai pais)
            => mapper.Map<Pai, IPaisDTO>(pais);

        private List<IPaisDTO> MapListIPaisDTO(List<Pai> pais)
            => mapper.Map<List<Pai>, List<IPaisDTO>>(pais);

        #endregion Metodos Privados
    }
}