using backend.Models;

namespace backend.Repositories.user
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}
