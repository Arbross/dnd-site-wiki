using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Entities
{
    public class User : IdentityUser, IBaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        // Navigation Properties
        public virtual List<PlayerList> PlayerList { get; set; }
    }
}
