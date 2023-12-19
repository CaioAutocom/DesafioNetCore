using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Application;

public class UserService : IProductService
{
    private readonly IUnitOfWork _uow;

    public UserService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public void Add(User user)
    {
        _uow.UserRespository.Add(user);
        _uow.CommitIdentity();
    }

    public IEnumerable<User> GetAll()
    {
        return _uow.UserRespository.GetAll();
    }
}
