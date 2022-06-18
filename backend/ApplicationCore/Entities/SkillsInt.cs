using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class SkillsInt : IBaseEntity
    {
        public Guid Id { get; set; }
        public int Arcana { get; set; }
        public int History { get; set; }
        public int Investigation { get; set; }
        public int Nature { get; set; }
        public int Religion { get; set; }
    }
}
