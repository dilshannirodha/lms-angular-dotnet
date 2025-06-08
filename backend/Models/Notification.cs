namespace backend.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
