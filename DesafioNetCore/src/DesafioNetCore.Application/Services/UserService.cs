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
        _uow.UserRespository.Add(user);
        _uow.CommitIdentity();
    }

    public Task<User> Delete(Guid guid)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        return _uow.UserRespository.GetAll();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsyn(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByShortId(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(User entity)
    {
        throw new NotImplementedException();
    }

    Task<User> IServiceBase<User>.AddAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
