namespace backend.DTOs
{
    public class UpdateStudentUploadDto
    {
        public string? Subject { get; set; }
        public List<string>? Uploads { get; set; }
        public decimal? Marks { get; set; }
        public string? Feedback { get; set; }
    }
}
