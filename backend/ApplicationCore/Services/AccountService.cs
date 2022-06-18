using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static ApplicationCore.Exceptions.HttpExeption;

namespace ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<JwtOptions> _jwtOptions;

        public AccountService(UserManager<User> userManager, IOptions<JwtOptions> jwtOptions, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
            _roleManager = roleManager;
        }

        public async Task<AuthorizationDTO> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException("Invalid login or password.", System.Net.HttpStatusCode.BadRequest);
            }

            // Generation token
            return new AuthorizationDTO
            {
                Token = GenerateToken(email),
                UserId = user.Id,
                UserRoles = await _userManager.GetRolesAsync(user)
            };
        }

        private string GenerateToken(string email)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: _jwtOptions.Value.Issuer,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(_jwtOptions.Value.LifeTime),
                    signingCredentials: credentials
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RegisterAsync(RegisterUserDTO data)
        {
            var user = new User()
            {
                UserName = data.UserName,
                Email = data.Email,
                FirstName = data.FirstName,
                SecondName = data.SecondName
            };
            var userResult = await _userManager.CreateAsync(user, data.Password);

            if (!userResult.Succeeded)
            {
                StringBuilder messageBuilder = new StringBuilder();

                foreach (var error in userResult.Errors)
                {
                    messageBuilder.AppendLine(error.Description);
                }

                throw new HttpException(messageBuilder.ToString(), System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                // Dev feature -> realiase fix
                if (!_roleManager.Roles.Any(x => x.Name == "Player"))
                {
                    await _roleManager.CreateAsync(new IdentityRole() 
                    {
                        Name = "Player",
                        NormalizedName = "PLAYER"
                    });
                }

                var roleResult = await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(user.Email), "Player");

                if (!roleResult.Succeeded)
                {
                    StringBuilder messageBuilder = new StringBuilder();

                    foreach (var error in roleResult.Errors)
                    {
                        messageBuilder.AppendLine(error.Description);
                    }

                    throw new HttpException(messageBuilder.ToString(), System.Net.HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
