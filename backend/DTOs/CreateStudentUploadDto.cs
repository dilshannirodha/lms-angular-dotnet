namespace backend.DTOs
{
    public class CreateStudentUploadDto
    {
        public string StudentId { get; set; }
        public string Subject { get; set; }
        public List<string> Uploads { get; set; } = new List<string>();
        public decimal Marks { get; set; }
        public string? Feedback { get; set; }
    }
}
