using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Infra.Repository;

public class UnitRepository : IUnitRepository
{
    private readonly AppDbContext _context;

    public UnitRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Unit entity)
    {
        
    }

    public async Task<Unit> AddAsync(Unit entity)
    {
       await _context.Units.AddAsync(entity);
        
        return entity;
    }

    public Task<Unit> Delete(Guid guid)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Unit> GetAll()
    {
        return _context.Units;
    }

    public Task<IEnumerable<Unit>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Unit> GetByIdAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> GetByShortIdAsync(string shortId)
    {
        throw new NotImplementedException();
    }

    public Task<Unit> UpdateAsync(Unit entity)
    {
        throw new NotImplementedException();
    }
}
