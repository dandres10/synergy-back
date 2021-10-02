namespace API.DTO.Entidades.Registrotarjeta
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;

    public class RegistrotarjetaMapperProfiles : Profile
    {
        public RegistrotarjetaMapperProfiles()
        {
            CreateMap<RegistroTarjetum, IRegistrotarjetaDTO>().ReverseMap();
            CreateMap<RegistrotarjetaBO, IRegistrotarjetaDTO>().ReverseMap();
            CreateMap<RegistrotarjetaDTO, IRegistrotarjetaDTO>().ReverseMap();
            CreateMap<EditarRegistrotarjetaDTO, IRegistrotarjetaDTO>().ReverseMap();
            CreateMap<GuardarRegistrotarjetaDTO, IRegistrotarjetaDTO>().ReverseMap();
            CreateMap<Respuesta<RegistrotarjetaDTO>, Respuesta<IRegistrotarjetaDTO>>().ReverseMap();
            CreateMap<Respuesta<EditarRegistrotarjetaDTO>, Respuesta<IRegistrotarjetaDTO>>().ReverseMap();
            CreateMap<Respuesta<GuardarRegistrotarjetaDTO>, Respuesta<IRegistrotarjetaDTO>>().ReverseMap();
            CreateMap<Respuesta<List<RegistrotarjetaDTO>>, Respuesta<List<IRegistrotarjetaDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<RegistroTarjetum>>, Respuesta<List<IRegistrotarjetaDTO>>>().ReverseMap();
        }
    }
}