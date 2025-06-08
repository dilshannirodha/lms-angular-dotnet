using backend.Models;

namespace backend.Repositories.NotificationRepo
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification?> GetByIdAsync(int id);
        Task AddAsync(Notification notification);
        Task DeleteAsync(int id);
        Task<IEnumerable<Notification>> GetByUserAsync(string username);
    }
}
