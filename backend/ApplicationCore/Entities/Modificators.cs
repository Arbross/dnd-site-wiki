using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Modificators : IBaseEntity
    {
        public Guid Id { get; set; }
        public int? StrengthModificator { get; set; }
        public int? DexterityModificator { get; set; }
        public int? ConstitutionModificator { get; set; }
        public int? InteligenceModificator { get; set; }
        public int? WisdomModificator { get; set; }
        public int? CharismaModificator { get; set; }
    }
}
