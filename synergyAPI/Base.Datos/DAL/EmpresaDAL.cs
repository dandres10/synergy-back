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

    public class EmpresaDAL : AccesoComunDAL, IEmpresaAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public EmpresaDAL(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Respuesta<List<IEmpresaDTO>>> ConsultarListaEmpresa()
                => await EjecutarTransaccionAsync(async () =>
                   {
                       List<Empresa> empresa = await context.Empresas.AsNoTracking().ToListAsync();
                       if (IsNull(empresa))
                           return CrearRespuesta<IEmpresaDTO>.AdvertenciaLista(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IEmpresaDTO>.ExitosaLista(MapListIEmpresaDTO(empresa));
                   });

        public async Task<Respuesta<IEmpresaDTO>> ConsultarEmpresa(IEmpresaDTO empresa)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       Empresa empresaDO = MapEmpresa(empresa);
                       empresaDO = await context.Empresas.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(empresaDO.Id));
                       if (IsNull(empresaDO))
                           return CrearRespuesta<IEmpresaDTO>.Advertencia(null, MensajesBaseEspanol.NoData);
                       return CrearRespuesta<IEmpresaDTO>.Exitosa(MapIEmpresaDTO(empresaDO), MensajesBaseEspanol.SuccessfulConsultation);
                   });

        public async Task<Respuesta<IEmpresaDTO>> EditarEmpresa(IEmpresaDTO empresa)
                => await EjecutarTransaccionAsync(async () => 
                   {
                       Empresa empresaDO = MapEmpresa(empresa);
                       context.Entry(empresaDO).State = EntityState.Modified;
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IEmpresaDTO>.Exitosa(null, MensajesBaseEspanol.UpdateData);
                   });

        public async Task<Respuesta<IEmpresaDTO>> EliminarEmpresa(IEmpresaDTO empresa)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       Empresa empresaDO = MapEmpresa(empresa);
                       context.Empresas.Remove(empresaDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IEmpresaDTO>.Exitosa(null, MensajesBaseEspanol.DeleteData);
                   });

        public async Task<Respuesta<IEmpresaDTO>> GuardarEmpresa(IEmpresaDTO empresa)
                => await EjecutarTransaccionAsync(async () =>
                   {
                       Empresa empresaDO = MapEmpresa(empresa);
                       empresaDO.Id = Guid.NewGuid();
                       context.Empresas.Add(empresaDO);
                       await context.SaveChangesAsync();
                       return CrearRespuesta<IEmpresaDTO>.Exitosa(null, MensajesBaseEspanol.CreateData);
                   });

        #region Metodos Privados

        private Empresa MapEmpresa(IEmpresaDTO empresa)
            => mapper.Map<IEmpresaDTO, Empresa>(empresa);

        private IEmpresaDTO MapIEmpresaDTO(Empresa empresa)
            => mapper.Map<Empresa, IEmpresaDTO>(empresa);

        private List<IEmpresaDTO> MapListIEmpresaDTO(List<Empresa> empresa)
            => mapper.Map<List<Empresa>, List<IEmpresaDTO>>(empresa);

        #endregion Metodos Privados
    }
}