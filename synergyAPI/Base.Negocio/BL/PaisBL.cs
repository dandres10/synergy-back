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
    
    public class PaisBL : AccesoComunBL, IPaisAccion
    {
        private readonly PaisDAL paisDAL;
        private readonly IMapper mapper;
        private readonly Context context;
    
        public PaisBL(PaisDAL paisDAL, IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
            this.paisDAL = paisDAL;
        }
   
       public async Task<Respuesta<List<IPaisDTO>>> ConsultarListaPais()
            => await EjecutarTransaccionAsync(async () => await paisDAL.ConsultarListaPais());
   
        public async Task<Respuesta<IPaisDTO>> ConsultarPais(IPaisDTO pais)
            => await EjecutarTransaccionAsync(async () => await paisDAL.ConsultarPais(pais));
    
        public async Task<Respuesta<IPaisDTO>> EditarPais(IPaisDTO pais)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IPaisDTO> respuestaDAL = await paisDAL.ConsultarPais(pais);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await paisDAL.EditarPais(pais);
            });
      
        public async Task<Respuesta<IPaisDTO>> EliminarPais(IPaisDTO pais)
            => await EjecutarTransaccionAsync(async () =>
             {
                 Respuesta<IPaisDTO> respuestaDAL = await paisDAL.ConsultarPais(pais);
                 if (!respuestaDAL.EsValido) return respuestaDAL;
                 return await paisDAL.EliminarPais(pais);
             });
       
        public async Task<Respuesta<IPaisDTO>> GuardarPais(IPaisDTO pais)
            => await EjecutarTransaccionAsync(async () => await paisDAL.GuardarPais(pais));
    }
}
