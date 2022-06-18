using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class SkillsCha : IBaseEntity
    {
        public Guid Id { get; set; }
        public int Deception { get; set; }
        public int Intimidation { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }
    }
}
