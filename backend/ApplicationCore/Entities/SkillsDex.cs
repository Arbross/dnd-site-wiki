using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class SkillsDex : IBaseEntity
    {
        public Guid Id { get; set; }
        public int Acrobatics { get; set; }
        public int SleightOfHand { get; set; }
        public int Stealth { get; set; }
    }
}
