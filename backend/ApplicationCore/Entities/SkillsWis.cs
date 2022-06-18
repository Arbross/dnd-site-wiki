using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class SkillsWis : IBaseEntity
    {
        public Guid Id { get; set; }
        public int AnimalHandling { get; set; }
        public int Insight { get; set; }
        public int Medicine { get; set; }
        public int Pesception { get; set; }
        public int Survival { get; set; }
    }
}
