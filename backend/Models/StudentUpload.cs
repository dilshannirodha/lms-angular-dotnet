namespace backend.Models
{
    public class StudentUpload
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public string Subject { get; set; }
        public List<string> Uploads { get; set; } = new List<string>();
        public decimal Marks { get; set; }
        public string? Feedback { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    }
}
