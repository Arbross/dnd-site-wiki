using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public enum DamageType
    {
        Abjuration = 0,
        Alteration,
        Conjuration,
        Divination,
        Enchantment,
        Illusion,
        Invocation,
        Necromancy
    }

    public class Spell : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Level { get; set; }
        public uint Area { get; set; }
        public string Components { get; set; }
        public DamageType DamageType { get; set; }
        public string Duration { get; set; }
        public uint CastingTimeByActions { get; set; }
        public string Description { get; set; }
    }
}
