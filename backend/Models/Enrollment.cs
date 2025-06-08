namespace backend.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string CourseId { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }

}
