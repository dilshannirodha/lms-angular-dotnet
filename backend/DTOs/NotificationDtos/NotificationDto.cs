namespace backend.DTOs.NotificationDtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
