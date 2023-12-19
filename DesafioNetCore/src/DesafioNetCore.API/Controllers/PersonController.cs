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
            _uow.PersonRepository.Add(person);
            _uow.Commit();
        }
        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _uow.PersonRepository.GetAll();
        }
    }
}
