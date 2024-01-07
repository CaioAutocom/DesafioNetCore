using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Infra.Repository.Contracts;

public interface IUnitRepository : IRepositoryBase<Unit>
{
    Task<Unit> GetByAcronym(string acronym);
}
