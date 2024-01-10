using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Infra.Repository.Contracts;

public interface IProductRepository : IRepositoryBase<Product>
{
    Task<bool> BarCodeDoesNotExistAsync(string barCode);
}
