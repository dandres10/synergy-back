namespace API.DTO.Entidades.Persona
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;

    public class PersonaMapperProfiles : Profile
    {
        public PersonaMapperProfiles()
        {
            CreateMap<Persona, IPersonaDTO>().ReverseMap();
            CreateMap<PersonaBO, IPersonaDTO>().ReverseMap();
            CreateMap<PersonaDTO, IPersonaDTO>().ReverseMap();
            CreateMap<EditarPersonaDTO, IPersonaDTO>().ReverseMap();
            CreateMap<GuardarPersonaDTO, IPersonaDTO>().ReverseMap();
            CreateMap<Respuesta<PersonaDTO>, Respuesta<IPersonaDTO>>().ReverseMap();
            CreateMap<Respuesta<EditarPersonaDTO>, Respuesta<IPersonaDTO>>().ReverseMap();
            CreateMap<Respuesta<GuardarPersonaDTO>, Respuesta<IPersonaDTO>>().ReverseMap();
            CreateMap<Respuesta<List<PersonaDTO>>, Respuesta<List<IPersonaDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<Persona>>, Respuesta<List<IPersonaDTO>>>().ReverseMap();
        }
    }
}