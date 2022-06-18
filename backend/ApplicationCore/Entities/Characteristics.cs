using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Characteristics : IBaseEntity
    {
        public Guid Id { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Inteligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
    }
}
