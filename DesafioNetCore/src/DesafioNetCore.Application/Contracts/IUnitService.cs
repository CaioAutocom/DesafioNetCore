using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Application.Contracts
{
    public interface IUnitService : IServiceBase<Unit>
    {
        Task<Unit> GetByAcronym(string acronym);
    }
}
