using backend.DTOs.NotificationDtos;
using backend.Models;
using backend.Repositories.NotificationRepo;

namespace backend.Services.NotificationServices
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;

        public NotificationService(INotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<NotificationDto>> GetAllAsync()
        {
            var notifications = await _repo.GetAllAsync();
            return notifications.Select(n => new NotificationDto
            {
                Id = n.Id,
                Username = n.Username,
                Message = n.Message,
                CreatedAt = n.CreatedAt
            });
        }

        public async Task<IEnumerable<NotificationDto>> GetByUserAsync(string username)
        {
            var notifications = await _repo.GetByUserAsync(username);
            return notifications.Select(n => new NotificationDto
            {
                Id = n.Id,
                Username = n.Username,
                Message = n.Message,
                CreatedAt = n.CreatedAt
            });
        }

        public async Task CreateAsync(CreateNotificationDto dto)
        {
            var notification = new Notification
            {
                Username = dto.Username,
                Message = dto.Message,
                CreatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(notification);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
