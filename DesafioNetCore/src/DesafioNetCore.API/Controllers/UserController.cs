using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {   
        private readonly IUserService _userService;

        public UserController(IUserService userService)
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
