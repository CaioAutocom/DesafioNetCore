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

        public void Add(Person person)
        {
            _context.Add(person);
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons;
        }
    }
}
