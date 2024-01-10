using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Infra.Repository.Contracts;

public interface IPersonRepository : IRepositoryBase<Person>
{
    Task<Person> GetByDocAsync(string doc);
    Task<Person> GetByAlternativeCode(string alternativeCode);
}
