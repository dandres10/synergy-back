namespace API.DTO.Entidades.Personaempresa
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;

    public class PersonaempresaMapperProfiles : Profile
    {
        public PersonaempresaMapperProfiles()
        {
            CreateMap<PersonaEmpresa, IPersonaempresaDTO>().ReverseMap();
            CreateMap<PersonaEmpresaBO, IPersonaempresaDTO>().ReverseMap();
            CreateMap<PersonaempresaDTO, IPersonaempresaDTO>().ReverseMap();
            CreateMap<EditarPersonaempresaDTO, IPersonaempresaDTO>().ReverseMap();
            CreateMap<GuardarPersonaempresaDTO, IPersonaempresaDTO>().ReverseMap();
            CreateMap<Respuesta<PersonaempresaDTO>, Respuesta<IPersonaempresaDTO>>().ReverseMap();
            CreateMap<Respuesta<EditarPersonaempresaDTO>, Respuesta<IPersonaempresaDTO>>().ReverseMap();
            CreateMap<Respuesta<GuardarPersonaempresaDTO>, Respuesta<IPersonaempresaDTO>>().ReverseMap();
            CreateMap<Respuesta<List<PersonaempresaDTO>>, Respuesta<List<IPersonaempresaDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<PersonaEmpresa>>, Respuesta<List<IPersonaempresaDTO>>>().ReverseMap();
        }
    }
}