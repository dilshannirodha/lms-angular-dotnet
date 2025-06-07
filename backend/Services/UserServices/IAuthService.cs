using backend.DTOs.UserDros;

namespace backend.Services.UserServices
{
    public interface IAuthService
    {
        Task<AuthResponse?> AuthenticateAsync(LoginRequest request);
        Task<bool> RegisterAsync(string username, string password, string role);
    }
}
