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
    
    public class PersonasedeBL : AccesoComunBL, IPersonasedeAccion
    {
        private readonly PersonasedeDAL personasedeDAL;
        private readonly IMapper mapper;
        private readonly Context context;
    
        public PersonasedeBL(PersonasedeDAL personasedeDAL, IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
            this.personasedeDAL = personasedeDAL;
        }
   
       public async Task<Respuesta<List<IPersonasedeDTO>>> ConsultarListaPersonasede()
            => await EjecutarTransaccionAsync(async () => await personasedeDAL.ConsultarListaPersonasede());
   
        public async Task<Respuesta<IPersonasedeDTO>> ConsultarPersonasede(IPersonasedeDTO personasede)
            => await EjecutarTransaccionAsync(async () => await personasedeDAL.ConsultarPersonasede(personasede));
    
        public async Task<Respuesta<IPersonasedeDTO>> EditarPersonasede(IPersonasedeDTO personasede)
            => await EjecutarTransaccionAsync(async () =>
            {
                Respuesta<IPersonasedeDTO> respuestaDAL = await personasedeDAL.ConsultarPersonasede(personasede);
                if (!respuestaDAL.EsValido) return respuestaDAL;
                return await personasedeDAL.EditarPersonasede(personasede);
            });
      
        public async Task<Respuesta<IPersonasedeDTO>> EliminarPersonasede(IPersonasedeDTO personasede)
            => await EjecutarTransaccionAsync(async () =>
             {
                 Respuesta<IPersonasedeDTO> respuestaDAL = await personasedeDAL.ConsultarPersonasede(personasede);
                 if (!respuestaDAL.EsValido) return respuestaDAL;
                 return await personasedeDAL.EliminarPersonasede(personasede);
             });
       
        public async Task<Respuesta<IPersonasedeDTO>> GuardarPersonasede(IPersonasedeDTO personasede)
            => await EjecutarTransaccionAsync(async () => await personasedeDAL.GuardarPersonasede(personasede));
    }
}
