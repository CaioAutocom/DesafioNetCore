using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DesafioNetCore.Infra.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Person> AddAsync(Person entity)
    {
        await _context.Persons.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _context.Persons.ToListAsync();
    }
    // não será usado
    public async Task<Person> GetByIdAsync(Guid guid)
    {
        return await _context.Persons.FindAsync(guid);
    }
    public async Task<Person> GetByAcronym(string acronym)
    {
        return await _context.Persons.FindAsync(acronym);
    }

    public async Task<Person> GetByShortIdAsync(string shortId)
    {
        return await _context.Persons.FirstOrDefaultAsync(u => u.ShortId == shortId);
    }

    public async Task<Person> UpdateAsync(Person entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public async Task<bool> DeleteAsync(string shortId)
    {
        var removed = _context.Remove(await _context.Persons.SingleOrDefaultAsync(x => x.ShortId == shortId));
        return removed != null;
    }

    public async Task<Person> GetByDocAsync(string doc)
    {
        return await _context.Persons.SingleOrDefaultAsync(x => x.Document == doc);
    }

    public async Task<Person> GetByAlternativeCode(string alternativeCode)
    {
        return await _context.Persons.SingleOrDefaultAsync(x => x.AlternativeIdentifier == alternativeCode);
    }

    public async Task<IEnumerable<Person>> GetClientsAsync()
    {
        return await _context.Persons.Where(x => x.CanBuy).ToListAsync();
    }
}
