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
        _context.Add(entity);
    }

    public IEnumerable<Unit> GetAll()
    {
        return _context.Units;
    }
}
