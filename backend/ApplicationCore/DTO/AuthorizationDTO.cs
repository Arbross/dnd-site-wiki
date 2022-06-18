using ApplicationCore.Entities;

namespace ApplicationCore.DTO
{
    public class AuthorizationDTO
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }
}
