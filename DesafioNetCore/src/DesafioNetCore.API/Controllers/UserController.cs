using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Application.Services;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "ADMINISTRATOR, MANAGER")]
    public class UserController : ControllerBase
    {   
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public void Add(User user)
        {
            _userService.AddAsync(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<GetUsersResponse>>(await _userService.GetAllAsync()));
        }

        [HttpGet("get-admin-users")]
        public async Task<IActionResult> GetAdminByRolesAsync()
        {
            return Ok(_mapper.Map<List<GetUsersResponse>>(await _userService.GetByRolesAsync(EAccessPriority.Administrator)));
        }
        [HttpGet("get-manager-users")]
        public async Task<IActionResult> GetManagersByRolesAsync()
        {
            return Ok(_mapper.Map<List<GetUsersResponse>>(await _userService.GetByRolesAsync(EAccessPriority.Manager)));
        }
        [HttpGet("get-sellers-users")]
        public async Task<IActionResult> GetSellersByRolesAsync()
        {
            return Ok(_mapper.Map<List<GetUsersResponse>>(await _userService.GetByRolesAsync(EAccessPriority.Seller)));
        }
    }
}
