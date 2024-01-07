using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Infra.Repository.Contracts;

public interface IRepositoryBase<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid guid);
    Task<T> GetByShortIdAsync(string shortId);
    Task<T> UpdateAsync(T entity);
    Task<T> Delete(Guid guid);
}
