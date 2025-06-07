namespace backend.Models
{
    public class StudentFile
    {
        public int Id { get; set; }
        public string StudentId { get; set; }  // Changed to string
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
