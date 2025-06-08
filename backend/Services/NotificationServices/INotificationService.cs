using backend.DTOs.NotificationDtos;

namespace backend.Services.NotificationServices
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllAsync();
        Task<IEnumerable<NotificationDto>> GetByUserAsync(string username);
        Task CreateAsync(CreateNotificationDto dto);
        Task DeleteAsync(int id);
    }
}
