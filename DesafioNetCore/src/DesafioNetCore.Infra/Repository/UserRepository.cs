using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Contracts;

namespace DesafioNetCore.Infra.Repository;

public class UserRepository : IUserRespository
{
    private readonly IdentityContext _context;

    public UserRepository(IdentityContext context)
    {
        _context = context;
    }
    public void Add(User user)
    {
        _context.Users.Add(user);
    }
    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }
}
