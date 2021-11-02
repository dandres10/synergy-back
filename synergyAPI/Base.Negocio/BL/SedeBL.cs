namespace Base.Negocio.BL
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.Datos.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.Configuracion;
    using Base.Transversal.Clases;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SedeBL : AccesoComunBL, ISedeAccion
    {
        private readonly SedeDAL sedeDAL;
        private readonly IMapper mapper;
        private readonly Context context;

        public SedeBL(SedeDAL sedeDAL, IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
            this.sedeDAL = sedeDAL;
        }

        public async Task<Respuesta<List<ISedeDTO>>> ConsultarListaSede(Guid Empresa)
             => await EjecutarTransaccionAsync<List<ISedeDTO>>(async () => await sedeDAL.ConsultarListaSede(Empresa));

        public async Task<Respuesta<ISedeDTO>> ConsultarSede(ISedeDTO sede)
            => await EjecutarTransaccionAsync<ISedeDTO>(async () => await sedeDAL.ConsultarSede(sede));

        public async Task<Respuesta<ISedeDTO>> EditarSede(ISedeDTO sede)
            => await EjecutarTransaccionAsync<ISedeDTO>(async () =>
            {
                Respuesta<ISedeDTO> respuestaDAL = await sedeDAL.ConsultarSede(sede);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                sede.FechaInicial = respuestaDAL.Resultado.FechaInicial;
                return await sedeDAL.EditarSede(sede);
            });

        public async Task<Respuesta<ISedeDTO>> EliminarSede(ISedeDTO sede)
            => await EjecutarTransaccionAsync<ISedeDTO>(async () =>
             {
                 Respuesta<ISedeDTO> respuestaDAL = await sedeDAL.ConsultarSede(sede);
                 if (!respuestaDAL.EsValido) return respuestaDAL;
                 return await sedeDAL.EliminarSede(sede);
             });

        public async Task<Respuesta<ISedeDTO>> GuardarSede(ISedeDTO sede)
            => await EjecutarTransaccionAsync<ISedeDTO>(async () => await sedeDAL.GuardarSede(sede));
    }
}