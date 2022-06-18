using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DnD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO data)
        {
            await _accountService.RegisterAsync(data);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthorizationDTO>> Login([FromBody] UserLoginDTO data)
        {
            return await _accountService.LoginAsync(data.Email, data.Password);
        }
    }
}
