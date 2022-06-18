using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class PlayerList : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Class { get; set; }
        public uint Level { get; set; }
        public string Race { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }
        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public int ExpPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public uint Speed { get; set; }
        public int CHitPoints { get; set; }
        public int THitPoints { get; set; }
        public string Traits { get; set; }
        public string Ideals { get; set; }
        public string Attachments { get; set; }
        public string Weakness { get; set; }
        public int BronzeCoins { get; set; }
        public bool IsDead { get; set; }

        // Navigation Properties
        public virtual Characteristics Characteristics { get; set; }
        public virtual Modificators Modificators { get; set; }
        public virtual SkillsCha SkillsCha { get; set; }
        public virtual SkillsDex SkillsDex { get; set; }
        public virtual SkillsInt SkillsInt { get; set; }
        public virtual SkillsStr SkillsStr { get; set; }
        public virtual SkillsWis SkillsWis { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<Spell> Spells { get; set; }
        public virtual Appearance Appearance { get; set; }
        public virtual List<Organization> Organizations { get; set; }
    }
}
