using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Application.Contracts
{
    public interface IPersonService : IServiceBase<Person>
    {
        Task<IEnumerable<Person>> GetClientsAsync();
    }
}
