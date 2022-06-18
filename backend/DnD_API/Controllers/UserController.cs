using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DnD_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.Get();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            _logger.LogDebug($"Getting a user with id {id}");

            var user = await _userService.Get(id);

            if (user == null)
            {
                _logger.LogError($"Not found a user with id {id}");
                return null;
            }

            _logger.LogInformation($"Got a user with id {id}");

            return user;
        }

        [HttpPost("add-role")]
        [ResponseCache(Duration = 3)]
        public async Task<ActionResult> AddRole([FromBody] IdentityRole role)
        {
            await _userService.AddUserRole(role);

            _logger.LogInformation($"Role was succesfully added!");

            return Ok();
        }

        [HttpGet("get-roles/{id}")]
        [ResponseCache(Duration = 3)]
        public async Task<IEnumerable<string>> GetUserRoles(string id)
        {
            _logger.LogDebug($"Getting a roles with user id {id}");

            var roles = await _userService.GetUserRoles(id);

            if (roles == null)
            {
                _logger.LogError($"Not found roles with id {id}");
                return null;
            }

            _logger.LogInformation($"Got roles with id {id}");

            return roles;
        }

        [HttpDelete("delete-role")]
        [ResponseCache(Duration = 3)]
        public async Task<ActionResult> DeleteRole([FromBody] IdentityRole role)
        {
            await _userService.RemoveUserRole(role);

            _logger.LogInformation($"Role was succesfully removed!");

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] User user)
        {
            await _userService.Update(user);

            _logger.LogInformation($"User was succesfully updated!");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _userService.Remove(id);

            _logger.LogInformation($"User was succesfully deleted!");

            return Ok();
        }
    }
}
