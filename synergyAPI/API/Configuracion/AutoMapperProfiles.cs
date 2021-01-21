namespace API.Configuracion
{
    using API.CO.Entidades;
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            Persona();
        }

        public void Persona()
        {
            CreateMap<Respuesta<PersonaDTO>, Respuesta<IPersonaDTO>>().ReverseMap();
            CreateMap<Respuesta<List<PersonaDTO>>, Respuesta<List<IPersonaDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<Persona>>, Respuesta<List<IPersonaDTO>>>().ReverseMap();
            CreateMap<PersonaBO, IPersonaDTO>().ReverseMap();
            CreateMap<PersonaDTO, IPersonaDTO>().ReverseMap();
            CreateMap<Persona, IPersonaDTO>().ReverseMap();
        }
    }
}