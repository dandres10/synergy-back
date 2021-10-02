namespace API.DTO.Entidades.Pais
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;

    public class PaisMapperProfiles : Profile
    {
        public PaisMapperProfiles()
        {
            CreateMap<Pai, IPaisDTO>().ReverseMap();
            CreateMap<PaisBO, IPaisDTO>().ReverseMap();
            CreateMap<PaisDTO, IPaisDTO>().ReverseMap();
            CreateMap<EditarPaisDTO, IPaisDTO>().ReverseMap();
            CreateMap<GuardarPaisDTO, IPaisDTO>().ReverseMap();
            CreateMap<Respuesta<PaisDTO>, Respuesta<IPaisDTO>>().ReverseMap();
            CreateMap<Respuesta<EditarPaisDTO>, Respuesta<IPaisDTO>>().ReverseMap();
            CreateMap<Respuesta<GuardarPaisDTO>, Respuesta<IPaisDTO>>().ReverseMap();
            CreateMap<Respuesta<List<PaisDTO>>, Respuesta<List<IPaisDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<Pai>>, Respuesta<List<IPaisDTO>>>().ReverseMap();
        }
    }
}