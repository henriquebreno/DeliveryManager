using DeliveryManager.API.Models.User;
using DeliveryManager.Infra.Repositories.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManager.API.Controllers
{

    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }


        [HttpPost("Token")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return BuildToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserInfo model)
        {
            if (model == null)
            {
                return BadRequest("Dados inválidos");
            }

            if (!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                return BadRequest("A role especificada não existe.");
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,              
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, model.RoleName);

                if (roleResult.Succeeded)
                {
                    return Ok("Usuário criado e atribuído à role com sucesso.");
                }
                else
                {
                    return BadRequest(roleResult.Errors);
                }
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest("O nome da role não pode ser vazio.");
            }

            var role = new ApplicationRole { Name = roleName };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok("Role criada com sucesso.");
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route("Role")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        private UserToken BuildToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("meuValor", "oque voce quiser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
