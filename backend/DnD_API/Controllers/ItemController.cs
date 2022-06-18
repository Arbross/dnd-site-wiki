using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DnD_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public readonly IItemService _itemService;
        public readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger, IItemService itemService)
        {
            _itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _itemService.Get();
        }

        [HttpGet("{id}")]
        public async Task<Item> Get(Guid id)
        {
            _logger.LogDebug($"Getting a item with id {id}");

            var item = await _itemService.Get(id);

            if (item == null)
            {
                _logger.LogError($"Not found a item with id {id}");
                return null;
            }

            _logger.LogInformation($"Got a item with id {id}");

            return item;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Item item)
        {
            await _itemService.Create(item);

            _logger.LogInformation($"Item was succesfully added!");

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Item item)
        {
            await _itemService.Update(item);

            _logger.LogInformation($"Item was succesfully updated!");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _itemService.Remove(id);

            _logger.LogInformation($"Item was succesfully deleted!");

            return Ok();
        }
    }
}
