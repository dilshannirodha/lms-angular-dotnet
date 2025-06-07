namespace backend.DTOs.TeacherDtos
{
    public class UpdateTeacherDto
    {
        public string Username { get; set; }

        public string? Name { get; set; }
        public string? Subject { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
