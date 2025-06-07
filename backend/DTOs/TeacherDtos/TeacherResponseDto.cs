namespace backend.DTOs.TeacherDtos
{
    public class TeacherResponseDto
    {
        public string TeacherId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
