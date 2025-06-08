namespace backend.DTOs.TeacherEnrollmentDtos
{
    public class TeacherEnrollmentDto
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string TeacherId { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}
