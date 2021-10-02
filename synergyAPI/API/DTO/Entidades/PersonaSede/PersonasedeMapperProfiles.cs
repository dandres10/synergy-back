namespace API.DTO.Entidades.Personasede
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;

    public class PersonasedeMapperProfiles : Profile
    {
        public PersonasedeMapperProfiles()
        {
            CreateMap<PersonaSede, IPersonasedeDTO>().ReverseMap();
            CreateMap<PersonasedeBO, IPersonasedeDTO>().ReverseMap();
            CreateMap<PersonasedeDTO, IPersonasedeDTO>().ReverseMap();
            CreateMap<EditarPersonasedeDTO, IPersonasedeDTO>().ReverseMap();
            CreateMap<GuardarPersonasedeDTO, IPersonasedeDTO>().ReverseMap();
            CreateMap<Respuesta<PersonasedeDTO>, Respuesta<IPersonasedeDTO>>().ReverseMap();
            CreateMap<Respuesta<EditarPersonasedeDTO>, Respuesta<IPersonasedeDTO>>().ReverseMap();
            CreateMap<Respuesta<GuardarPersonasedeDTO>, Respuesta<IPersonasedeDTO>>().ReverseMap();
            CreateMap<Respuesta<List<PersonasedeDTO>>, Respuesta<List<IPersonasedeDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<PersonaSede>>, Respuesta<List<IPersonasedeDTO>>>().ReverseMap();
        }
    }
}