using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesafioNetCore.Infra.Repository;

public class UnitRepository : IUnitRepository
{
    private readonly AppDbContext _context;

    public UnitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> AddAsync(Unit entity)
    {
        await _context.Units.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<Unit>> GetAllAsync()
    {
        return await _context.Units.ToListAsync();
    }
    // não será usado
    public async Task<Unit> GetByIdAsync(Guid guid)
    {
        return await _context.Units.FindAsync(guid);
    }
    public async Task<Unit> GetByAcronymAsync(string acronym)
    {
        return await _context.Units.FindAsync(acronym);
    }

    public async Task<Unit> GetByShortIdAsync(string shortId)
    {
        return await _context.Units.FirstOrDefaultAsync(u => u.ShortId == shortId);
    }

    public async Task<Unit> UpdateAsync(Unit entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public async Task<bool> DeleteAsync(string shortId)
    {
        var removed = _context.Remove(await _context.Units.SingleOrDefaultAsync(x => x.ShortId == shortId));
        return removed != null;    
    }

    public async Task<Unit> GetQueryable(Expression<Func<Unit, bool>> query)
    {
        return await _context.Units.SingleOrDefaultAsync(query);
    }
}
