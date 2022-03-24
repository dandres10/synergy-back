namespace API.DTO.Entidades.Empresa
{
    using AutoMapper;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.DTO.Entidades;
    using Base.Negocio.BO.Entidades;
    using Base.Transversal.Clases;
    using System.Collections.Generic;
    
    public class EmpresaMapperProfiles : Profile
    {
    
        public EmpresaMapperProfiles()
        {
            CreateMap<Empresa, IEmpresaDTO>().ReverseMap();
            CreateMap<EmpresaBO, IEmpresaDTO>().ReverseMap();
            CreateMap<EmpresaDTO, IEmpresaDTO>().ReverseMap();
            CreateMap<EditarEmpresaDTO, IEmpresaDTO>().ReverseMap();
            CreateMap<GuardarEmpresaDTO, IEmpresaDTO>().ReverseMap();
            CreateMap<Respuesta<EmpresaDTO>, Respuesta<IEmpresaDTO>>().ReverseMap();
            CreateMap<Respuesta<EditarEmpresaDTO>, Respuesta<IEmpresaDTO>>().ReverseMap();
            CreateMap<Respuesta<GuardarEmpresaDTO>, Respuesta<IEmpresaDTO>>().ReverseMap();
            CreateMap<Respuesta<List<EmpresaDTO>>, Respuesta<List<IEmpresaDTO>>>().ReverseMap();
            CreateMap<Respuesta<List<Empresa>>, Respuesta<List<IEmpresaDTO>>>().ReverseMap();
        }
    }
}
