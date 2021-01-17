namespace API.Configuracion
{
    using API.CO.Entidades;
    using AutoMapper;
    using Base.IC.DTO.Entidades;
    using Base.Transversal.Clases;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Mapper Persona

            CreateMap<Respuesta<PersonaCO>, Respuesta<IPersonaDTO>>().ReverseMap();
            CreateMap<PersonaCO, IPersonaDTO>().ReverseMap();
        }
    }
}