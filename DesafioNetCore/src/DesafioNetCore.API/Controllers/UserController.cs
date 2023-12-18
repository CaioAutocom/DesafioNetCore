using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {   
        private readonly  IUserRespository _userRespository;

        public UserController(IUserRespository userRespository)
        {
            _userRespository = userRespository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new List<User>();
        }
        [HttpPost]
        public void Add(User user)
        {
            _userRespository.Add(user);
            _userRespository.Save();
        }
    }
}
