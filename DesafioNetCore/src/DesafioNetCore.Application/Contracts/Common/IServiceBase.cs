namespace DesafioNetCore.Application.Contracts.Common;

public interface IServiceBase<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsyn(Guid guid);
    Task<T> GetByShortId(string shortId);
    Task<T> Update(T entity);
    Task<T> Delete(Guid guid);
}
