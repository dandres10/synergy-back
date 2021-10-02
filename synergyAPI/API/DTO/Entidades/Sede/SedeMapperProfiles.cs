namespace API.DTO.Entidades.Sede
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;

    public class SedeMapperProfiles : Profile
    {
        public SedeMapperProfiles()
        {
            CreateMap<Sede, ISedeDTO>().ReverseMap();
            CreateMap<SedeBO, ISedeDTO>().ReverseMap();
            CreateMap<SedeDTO, ISedeDTO>().ReverseMap();
            CreateMap<EditarSedeDTO, ISedeDTO>().ReverseMap();
            CreateMap<GuardarSedeDTO, ISedeDTO>().ReverseMap();
            CreateMap<Respuesta<SedeDTO>, Respuesta<ISedeDTO>>().ReverseMap();
            CreateMap<Respuesta<EditarSedeDTO>, Respuesta<ISedeDTO>>().ReverseMap();
            CreateMap<Respuesta<GuardarSedeDTO>, Respuesta<ISedeDTO>>().ReverseMap();
            CreateMap<Respuesta<List<SedeDTO>>, Respuesta<List<ISedeDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<Sede>>, Respuesta<List<ISedeDTO>>>().ReverseMap();
        }
    }
}