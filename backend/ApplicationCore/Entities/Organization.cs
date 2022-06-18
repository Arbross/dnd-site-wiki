using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Organization : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsFriend { get; set; }
        public int Reputation { get; set; }
        public string Description { get; set; }
    }
}
