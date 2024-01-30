using AutoMapper;
using DesafioNetCore.Application.Cqrs;
using DesafioNetCore.Application.Cqrs.Request.Product;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Application.Extensions
{
    internal class AutoMapperSettings : Profile
    {
        public AutoMapperSettings()
        {
            #region Units
            CreateMap<Unit, CreateUnitResponse>().ReverseMap();
            CreateMap<Unit, CreateUnitRequest>().ReverseMap();
            CreateMap<Unit, UpdateUnitRequest>().ReverseMap();
            CreateMap<Unit, UpdateUnitResponse>().ReverseMap();
            CreateMap<Unit, GetUnitsResponse>().ReverseMap();
            #endregion

            #region Person
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, CreatePersonResponse>().ReverseMap();
            CreateMap<Person, UpdatePersonRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonResponse>().ReverseMap();
            CreateMap<Person, GetPersonsResponse>().ReverseMap();
            #endregion

            #region Products
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, CreateProductResponse>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductResponse>().ReverseMap();
            CreateMap<Product, GetProductsResponse>().ReverseMap();
            #endregion

            #region Users
            CreateMap<User, GetUsersResponse>().ReverseMap();
            CreateMap<User, RegisterUserRequest>().ReverseMap();
            #endregion
        }
    }
}
