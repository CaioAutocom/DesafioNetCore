using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Infra.Repository;

public class UnitRepository : IUnitRepository
{
    private readonly AppDbContext _context;

    public UnitRepository(AppDbContext context)
    {
        _context = context;
    }
}
