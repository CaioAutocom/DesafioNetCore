using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {   
        private readonly IProductService _userService;

        public UserController(IProductService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }
        [HttpPost]
        public void Add(User user)
        {
            _userService.Add(user);
        }
    }
}
