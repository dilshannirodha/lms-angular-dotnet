using backend.DTOs;

namespace backend.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> AuthenticateAsync(LoginRequest request);
        Task<bool> RegisterAsync(string username, string password, string role);
    }
}
