namespace backend.DTOs.StudentEnrollmentDtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string StudentId { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}
