using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Infra.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Person> AddAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string shortId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByShortIdAsync(string shortId)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
