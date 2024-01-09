using FluentValidation;

namespace DesafioNetCore.Application.Contracts.Common;

public interface IServiceBase<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid guid);
    Task<T> GetByShortIdAsync(string shortId);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string shortId);
}
