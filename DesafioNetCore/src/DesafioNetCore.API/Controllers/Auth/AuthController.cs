using DesafioNetCore.API.CQRC;
using DesafioNetCore.API.Extensions;
using DesafioNetCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DesafioNetCore.API.Controllers.Auth
{

    [Route("api")]
    public class AuthController : MainController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new User
            {
                Name = registerUser.Name,
                Document = registerUser.Document,
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await AddUserRole(user, registerUser.AccessPriority.ToString().ToUpper());

                return CustomResponse(await CreateJwt(registerUser.Email));
            }

            foreach (var error in result.Errors)
            {
                AddErros(error.Description);
            }
            return CustomResponse();

        }

        private async Task AddUserRole(User user, string role) => await _userManager.AddToRoleAsync(user, role);

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await CreateJwt(loginUser.Email));
            }

            AddErros("Wrong user or password");
            return CustomResponse();
        }

        private async Task<UserResponseLogin> CreateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            // claims são permissoes ou dados abertos do usuário
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var identityClaims = await GetUserClaimsAsync(claims, user);
            var encodedToken = EncodeToken(identityClaims);

            return GetTokenResponse(encodedToken, user, claims, roles);

            // aula M03V07 Emitindo jwt no minuto 14 fala sobre refatoração deste método
        }

        private UserResponseLogin GetTokenResponse(string encodedToken, IdentityUser user, IList<Claim> claims, IList<string> roles)
        {
            // monta a resposta 
            return new UserResponseLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpireTime).TotalSeconds,
                UserToken = new UserToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    //Claims = claims.Select(x => new UserClaim { Type = x.Type, Value = x.Value }),
                    Roles = roles
                }
            };
        }

        private string EncodeToken(ClaimsIdentity identityClaims)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenhandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.LifeTime,
                // dados do usuario
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpireTime),
                // credenciais
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            
            return tokenhandler.WriteToken(token);
        }

        private async Task<ClaimsIdentity> GetUserClaimsAsync(ICollection<Claim> claims, User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnitEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnitEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private static long ToUnitEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
    }
}
