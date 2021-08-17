namespace Base.Negocio.BL
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.Datos.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.Configuracion;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public class EmpresaBL : AccesoComunBL, IEmpresaAccion
    {
        private readonly EmpresaDAL empresaDAL;
        private readonly IMapper mapper;
        private readonly Context context;
    
        public EmpresaBL(EmpresaDAL empresaDAL, IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
            this.empresaDAL = empresaDAL;
        }
   
       public async Task<Respuesta<List<IEmpresaDTO>>> ConsultarListaEmpresa()
            => await EjecutarTransaccionAsync(async () => await empresaDAL.ConsultarListaEmpresa());
   
        public async Task<Respuesta<IEmpresaDTO>> ConsultarEmpresa(IEmpresaDTO empresa)
            => await EjecutarTransaccionAsync(async () => await empresaDAL.ConsultarEmpresa(empresa));
    
        public async Task<Respuesta<IEmpresaDTO>> EditarEmpresa(IEmpresaDTO empresa)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IEmpresaDTO> respuestaDAL = await empresaDAL.ConsultarEmpresa(empresa);
                empresa.FechaInicial = respuestaDAL.Resultado.FechaInicial;
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await empresaDAL.EditarEmpresa(empresa);
            });
      
        public async Task<Respuesta<IEmpresaDTO>> EliminarEmpresa(IEmpresaDTO empresa)
            => await EjecutarTransaccionAsync(async () =>
             {
                 Respuesta<IEmpresaDTO> respuestaDAL = await empresaDAL.ConsultarEmpresa(empresa);
                 if (!respuestaDAL.EsValido) return respuestaDAL;
                 return await empresaDAL.EliminarEmpresa(empresa);
             });
       
        public async Task<Respuesta<IEmpresaDTO>> GuardarEmpresa(IEmpresaDTO empresa)
            => await EjecutarTransaccionAsync(async () => await empresaDAL.GuardarEmpresa(empresa));
    }
}
