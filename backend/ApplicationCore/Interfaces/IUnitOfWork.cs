using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<SkillsCha> SkillsChaRepository { get; }
        IRepository<SkillsDex> SkillsDexRepository { get; }
        IRepository<SkillsInt> SkillsIntRepository { get; }
        IRepository<SkillsStr> SkillsStrRepository { get; }
        IRepository<SkillsWis> SkillsWisRepository { get; }
        IRepository<Item> ItemRepository { get; }
        IRepository<Spell> SpellRepository { get; }
        IRepository<Modificators> ModificatorsRepository { get; }
        IRepository<Characteristics> CharacteristicsRepository { get; }
        IRepository<Organization> OrganizationRepository { get; }
        IRepository<PlayerList> PlayerListRepository { get; }
        IRepository<Appearance> AppearanceRepository { get; }
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
