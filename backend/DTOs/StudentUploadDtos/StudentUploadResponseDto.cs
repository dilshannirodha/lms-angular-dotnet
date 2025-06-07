namespace backend.DTOs.StudentUploadDtos
{
    public class StudentUploadResponseDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Subject { get; set; }
        public List<string> Uploads { get; set; }
        public decimal Marks { get; set; }
        public string? Feedback { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
