namespace backend.DTOs.StudentFilesDtos
{
    public class StudentFileDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
