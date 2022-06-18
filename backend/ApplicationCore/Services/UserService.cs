using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Net;
using static ApplicationCore.Exceptions.HttpExeption;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddUserRole(IdentityRole role)
        {
            var user = await _userManager.FindByIdAsync(role.Id);

            if (user == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            // Dev feature -> remove on release
            if (!_roleManager.Roles.Any(x => x.Name == "Player"))
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Player" });
            }

            if (!_roleManager.Roles.Any(x => x.Name == role.Name))
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task RemoveUserRole(IdentityRole role)
        {
            var user = await _userManager.FindByIdAsync(role.Id);

            if (user == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            if (!_roleManager.Roles.Any(x => x.Name == role.Name))
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            await _userManager.RemoveFromRoleAsync(user, role.Name);
        }

        public async Task Remove(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            IdentityResult result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new HttpException("Not succeeded delete.", HttpStatusCode.Conflict);
            }
        }

        public async Task<User> Get(string id)
        {
            var user = await _unitOfWork.UserRepository.GetIncludeAsync(x => x.Id == id, x => x.PlayerList);

            if (user == null)
            {
                throw new HttpException("Object not exist.", HttpStatusCode.NotFound);
            }

            return user;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string id)
        {
            return await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _unitOfWork.UserRepository.GetAsync(null, null, x => x.PlayerList);
        }

        public async Task Update(User user) => await _userManager.UpdateAsync(user);
    }
}
