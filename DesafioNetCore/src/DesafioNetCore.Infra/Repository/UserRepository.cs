using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public Task<User> GetByIdAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByShortIdAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetQueryable(Expression<Func<User, bool>> query)
    {
        return  await _context.Users.SingleOrDefaultAsync(query);
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

}
