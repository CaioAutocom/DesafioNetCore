using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Application.Services;

public class ProductService : IProductService
{
    public void AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Delete(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsyn(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByShortId(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Update(Product entity)
    {
        throw new NotImplementedException();
    }

    Task<Product> IServiceBase<Product>.AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    //IEnumerable<Product> IServiceBase<Product>.GetAll()
    //{
    //    throw new NotImplementedException();
    //}
}
