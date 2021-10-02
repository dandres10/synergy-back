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

    public class RegistrotarjetaBL : AccesoComunBL, IRegistrotarjetaAccion
    {
        private readonly RegistrotarjetaDAL registrotarjetaDAL;
        private readonly IMapper mapper;
        private readonly Context context;

        public RegistrotarjetaBL(RegistrotarjetaDAL registrotarjetaDAL, IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
            this.registrotarjetaDAL = registrotarjetaDAL;
        }

        public async Task<Respuesta<List<IRegistrotarjetaDTO>>> ConsultarListaRegistrotarjeta()
             => await EjecutarTransaccionAsync(async () => await registrotarjetaDAL.ConsultarListaRegistrotarjeta());

        public async Task<Respuesta<IRegistrotarjetaDTO>> ConsultarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
            => await EjecutarTransaccionAsync(async () => await registrotarjetaDAL.ConsultarRegistrotarjeta(registrotarjeta));

        public async Task<Respuesta<IRegistrotarjetaDTO>> EditarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IRegistrotarjetaDTO> respuestaDAL = await registrotarjetaDAL.ConsultarRegistrotarjeta(registrotarjeta);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                registrotarjeta.FechaInicio = respuestaDAL.Resultado.FechaInicio;
                return await registrotarjetaDAL.EditarRegistrotarjeta(registrotarjeta);
            });

        public async Task<Respuesta<IRegistrotarjetaDTO>> EliminarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
            => await EjecutarTransaccionAsync(async () =>
             {
                 Respuesta<IRegistrotarjetaDTO> respuestaDAL = await registrotarjetaDAL.ConsultarRegistrotarjeta(registrotarjeta);
                 if (!respuestaDAL.EsValido) return respuestaDAL;
                 return await registrotarjetaDAL.EliminarRegistrotarjeta(registrotarjeta);
             });

        public async Task<Respuesta<IRegistrotarjetaDTO>> GuardarRegistrotarjeta(IRegistrotarjetaDTO registrotarjeta)
            => await EjecutarTransaccionAsync(async () => await registrotarjetaDAL.GuardarRegistrotarjeta(registrotarjeta));
    }
}