﻿using AutoMapper;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Application.Extensions
{
    internal class AutoMapperSettings : Profile
    {
        public AutoMapperSettings()
        {
            CreateMap<Unit, CreateUnitResponse>().ReverseMap();
            CreateMap<Unit, CreateUnitRequest>().ReverseMap();
        }
    }
}
