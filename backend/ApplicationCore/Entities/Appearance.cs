using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Appearance : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Age { get; set; }
        public string Growth { get; set; }
        public string Weight { get; set; }
        public string EyesColor { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
    }
}
