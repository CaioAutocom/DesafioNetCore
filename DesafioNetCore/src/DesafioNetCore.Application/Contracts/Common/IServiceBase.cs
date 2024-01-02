namespace DesafioNetCore.Application.Contracts.Common;

public interface IServiceBase<T> where T : class
{
    void Add(T entity);
    IEnumerable<T> GetAll();
}
