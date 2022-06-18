using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IItemService
    {
        Task Create(Item item);
        Task<IEnumerable<Item>> Get();
        Task<Item> Get(Guid id);
        Task Update(Item item);
        Task Remove(Guid id);
    }
}
