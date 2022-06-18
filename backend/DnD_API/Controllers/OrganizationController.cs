using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DnD_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        public readonly IOrganizationService _organizationService;
        public readonly ILogger<OrganizationController> _logger;

        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationService organizationService)
        {
            _organizationService = organizationService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Organization>> Get()
        {
            return await _organizationService.Get();
        }

        [HttpGet("{id}")]
        public async Task<Organization> Get(Guid id)
        {
            _logger.LogDebug($"Getting a organization with id {id}");

            var organization = await _organizationService.Get(id);

            if (organization == null)
            {
                _logger.LogError($"Not found a organization with id {id}");
                return null;
            }

            _logger.LogInformation($"Got a organization with id {id}");

            return organization;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Organization organization)
        {
            await _organizationService.Create(organization);

            _logger.LogInformation($"Organization was succesfully added!");

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Organization organization)
        {
            await _organizationService.Update(organization);

            _logger.LogInformation($"Organization was succesfully updated!");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _organizationService.Remove(id);

            _logger.LogInformation($"Organization was succesfully deleted!");

            return Ok();
        }
    }
}
