namespace backend.DTOs.TeacherFileDtos
{
    public class CreateTeacherFileDto
    {
        public string TeacherId { get; set; }
        public IFormFile File { get; set; }
    }

}
