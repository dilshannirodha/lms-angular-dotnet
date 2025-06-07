namespace backend.DTOs.StudentFilesDtos
{
    public class CreateStudentFileDto
    {
        public string StudentId { get; set; }
        public IFormFile File { get; set; }
    }

}
