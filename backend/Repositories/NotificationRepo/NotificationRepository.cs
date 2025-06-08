using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.NotificationRepo
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync() =>
            await _context.Notifications.OrderByDescending(n => n.CreatedAt).ToListAsync();

        public async Task<Notification?> GetByIdAsync(int id) =>
            await _context.Notifications.FindAsync(id);

        public async Task AddAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Notification>> GetByUserAsync(string username) =>
            await _context.Notifications
                .Where(n => n.Username == username)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
    }       
}
