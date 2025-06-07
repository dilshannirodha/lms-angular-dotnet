namespace backend.Models
{
    public class TeacherFile
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }  // Changed to string
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
