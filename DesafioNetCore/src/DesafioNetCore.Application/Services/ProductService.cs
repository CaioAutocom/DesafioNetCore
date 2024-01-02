using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Application.Services;

public class ProductService : IProductService
{
    public void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Product> IServiceBase<Product>.GetAll()
    {
        throw new NotImplementedException();
    }
}
