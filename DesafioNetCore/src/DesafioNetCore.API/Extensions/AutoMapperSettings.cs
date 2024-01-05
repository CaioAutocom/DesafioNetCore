using AutoMapper;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.API;

public class AutoMapperSettings : Profile
{
    public AutoMapperSettings()
    {
        CreateMap<Unit, CreateUnitResponse>().ReverseMap();
        CreateMap<Unit, CreateUnitRequest>().ReverseMap();
    }
}
