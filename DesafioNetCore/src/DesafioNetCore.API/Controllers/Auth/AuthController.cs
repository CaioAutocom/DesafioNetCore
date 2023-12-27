using DesafioNetCore.API.CQRC;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DesafioNetCore.API.Controllers.Auth
{
    [ApiController] // Libera a documentação dos schemas da aplicação
    [Route("api")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register (RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return BadRequest();
    
            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }
            else
            {
                foreach (var item in result.Errors)
                {

                }
            }
            return BadRequest();

        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
