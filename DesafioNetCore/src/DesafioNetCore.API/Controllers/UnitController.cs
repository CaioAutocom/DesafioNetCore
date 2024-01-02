using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [Route("[controller]")]
    public class UnitController : MainController
    {
        private readonly IUnitOfWork _uow;
        public UnitController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IEnumerable<Unit> GetAll() 
        {
           return _uow.UnitRepository.GetAll();
        }

        [HttpPost]
        public void Add(Unit unit)
        {
            _uow.UnitRepository.Add(unit);
            _uow.Commit();
        }
    }
}
