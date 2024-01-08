using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Infra.Repository;

public class UserRepository : IUserRespository
{
    private readonly IdentityContext _context;

    public UserRepository(IdentityContext context)
    {
        _context = context;
    }

    public Task<User> AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> Delete(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByShortIdAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
