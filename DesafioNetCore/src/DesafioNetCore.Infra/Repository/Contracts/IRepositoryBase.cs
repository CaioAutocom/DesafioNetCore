using System.Linq.Expressions;

namespace DesafioNetCore.Infra.Repository.Contracts;

public interface IRepositoryBase<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid guid);
    Task<T> GetByShortIdAsync(string shortId);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string shortId);
    Task<T> GetQueryable(Expression<Func<T, bool>> query);
}
