using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Product> AddAsync(Product entity)
    {
        await _unitOfWork.ProductRepository.AddAsync(entity);
        _unitOfWork.Commit();
        return entity;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _unitOfWork.ProductRepository.GetAllAsync();
    }
    // nao vai ser utilizado este
    public async Task<Product> GetByIdAsync(Guid guid)
    {
        return await _unitOfWork.ProductRepository.GetByIdAsync(guid);
    }

    public async Task<Product> GetByShortIdAsync(string shortId)
    {
        return await _unitOfWork.ProductRepository.GetByShortIdAsync(shortId);
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        await _unitOfWork.ProductRepository.UpdateAsync(entity);
        _unitOfWork.Commit();
        return entity;
    }

    public async Task<bool> DeleteAsync(string shortId)
    {
        var deleted = await _unitOfWork.ProductRepository.DeleteAsync(shortId);
        _unitOfWork.Commit();

        return deleted;
    }
}
