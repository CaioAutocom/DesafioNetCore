using DesafioNetCore.Domain.Entities;

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

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }
}
