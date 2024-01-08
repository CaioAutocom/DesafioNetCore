using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Contracts.Common;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Application;

public class UserService : IUserService
{
    private readonly IUnitOfWork _uow;

    public UserService(IUnitOfWork uow)
    {
        _uow = uow;
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

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _uow.UserRespository.GetAllAsync();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsyn(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByShortId(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByShortIdAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(User entity)
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
