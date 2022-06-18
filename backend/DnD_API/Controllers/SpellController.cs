using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DnD_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : ControllerBase
    {
        public readonly ISpellsService _spellsService;
        public readonly ILogger<SpellController> _logger;

        public SpellController(ILogger<SpellController> logger, ISpellsService spellsService)
        {
            _spellsService = spellsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Spell>> Get()
        {
            return await _spellsService.Get();
        }

        [HttpGet("{id}")]
        public async Task<Spell> Get(Guid id)
        {
            _logger.LogDebug($"Getting a spell with id {id}");

            var spell = await _spellsService.Get(id);

            if (spell == null)
            {
                _logger.LogError($"Not found a spell with id {id}");
                return null;
            }

            _logger.LogInformation($"Got a spell with id {id}");

            return spell;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Spell spell)
        {
            await _spellsService.Create(spell);

            _logger.LogInformation($"Spell was succesfully added!");

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Spell spell)
        {
            await _spellsService.Update(spell);

            _logger.LogInformation($"Spell was succesfully updated!");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _spellsService.Remove(id);

            _logger.LogInformation($"Spell was succesfully deleted!");

            return Ok();
        }
    }
}
