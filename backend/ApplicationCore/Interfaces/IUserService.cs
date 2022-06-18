using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(string id);
        Task Update(User user);
        Task Remove(string id);
        Task AddUserRole(IdentityRole role);
        Task RemoveUserRole(IdentityRole role);
        Task<IEnumerable<string>> GetUserRoles(string id);
    }
}
