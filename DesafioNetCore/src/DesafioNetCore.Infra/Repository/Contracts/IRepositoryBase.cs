using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Infra.Repository.Contracts;

public interface IRepositoryBase<T> where T : class
{
    void Add(T entity);
    IEnumerable<T> GetAll();
}
