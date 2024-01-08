using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Application.Services;

public class ProductService : IProductService
{
    public Task<Product> AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByShortIdAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
