namespace backend.Models
{
    public class TeacherEnrollment
    {
        public int Id { get; set; }
        public string CourseId { get; set; } = string.Empty;
        public string TeacherId { get; set; } = string.Empty;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}
