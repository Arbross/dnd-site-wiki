using ApplicationCore.DTO;

namespace ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterUserDTO data);
        Task<AuthorizationDTO> LoginAsync(string email, string password);
        //Task LogoutAsync();
    }
}
