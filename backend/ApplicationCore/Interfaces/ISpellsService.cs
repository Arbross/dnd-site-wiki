using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ISpellsService
    {
        Task Create(Spell spell);
        Task<IEnumerable<Spell>> Get();
        Task<Spell> Get(Guid id);
        Task Update(Spell spell);
        Task Remove(Guid id);
    }
}
