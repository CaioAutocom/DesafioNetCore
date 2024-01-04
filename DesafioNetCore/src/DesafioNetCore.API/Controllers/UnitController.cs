using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [Route("[controller]")]
    public class UnitController : MainController
    {
        [HttpGet]
        public IEnumerable<Unit> GetAll() 
        {
           return _uow.UnitRepository.GetAll();
        }

        [HttpPost]
        public void Add(Unit unit)
        {
            
        }
    }
}
