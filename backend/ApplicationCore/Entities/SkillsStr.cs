using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class SkillsStr : IBaseEntity
    {
        public Guid Id { get; set; }
        public int Athletics { get; set; }
    }
}
