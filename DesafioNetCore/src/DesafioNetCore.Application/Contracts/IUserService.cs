using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Entities.Enums;

namespace DesafioNetCore.Application.Contracts
{
    public interface IUserService : IServiceBase<User>
    {
        Task<IList<User>> GetByRolesAsync(EAccessPriority accessPriority);
    }
}
