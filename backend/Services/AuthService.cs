using backend.DTOs;
using backend.Helpers;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(IUserRepository userRepo, JwtTokenGenerator jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }

        public async Task<AuthResponse?> AuthenticateAsync(LoginRequest request)
        {
            var user = await _userRepo.GetByUsernameAsync(request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return null;

            var token = _jwt.GenerateToken(user);
            return new AuthResponse
            {
                Token = token,
                Role = user.Role,
                Username = user.Username
            };
        }

        public async Task<bool> RegisterAsync(string username, string password, string role)
        {
            var existing = await _userRepo.GetByUsernameAsync(username);
            if (existing != null) return false;

            var newUser = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };

            await _userRepo.AddUserAsync(newUser);
            return true;
        }
    }
}
