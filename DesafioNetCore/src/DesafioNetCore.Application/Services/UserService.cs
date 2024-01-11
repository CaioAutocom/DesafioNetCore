using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Entities.Enums;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Identity;

namespace DesafioNetCore.Application;

public class UserService : IUserService
{
    private readonly IUnitOfWork _uow;
    private readonly UserManager<User> _userManager;
    public UserService(IUnitOfWork uow, UserManager<User> userManager)
    {
        _uow = uow;
        _userManager = userManager;
    }

    public void AddAsync(User user)
    {
        _uow.UserRespository.AddAsync(user);
        _uow.CommitIdentity();
    }

    public Task<bool> DeleteAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return _uow.UserRespository.GetAllAsync();
    }

    public Task<User> GetByIdAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<User>> GetByRolesAsync(EAccessPriority accessPriority)
    {
        return await _userManager.GetUsersInRoleAsync(accessPriority.ToString());
    }

    public Task<User> GetByShortIdAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    Task<User> IServiceBase<User>.AddAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
