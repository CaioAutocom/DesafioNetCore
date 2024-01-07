using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController
    {
        private readonly IUnitOfWork _uow;

        public PersonController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public void Add(Person person)
        {
            _uow.PersonRepository.AddAsync(person);
            _uow.Commit();
        }
        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _uow.PersonRepository.GetAllAsync();
        }
    }
}
