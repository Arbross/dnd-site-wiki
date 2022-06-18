using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public enum ItemType
    {
        Armor = 0,
        Potion,
        Ring,
        Rod,
        Scroll,
        Staff,
        Wand,
        Weapon,
        Wondrous
    }

    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Very_Rare,
        Legendary,
        Artifact,
        Varies,
        Unknown_Rarity
    }

    public class Item : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public uint Cost { get; set; }
        public ItemRarity Rarity { get; set; }
        public uint Weight { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
        public string Image { get; set; }
    }
}
