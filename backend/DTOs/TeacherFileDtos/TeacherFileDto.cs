namespace backend.DTOs.TeacherFileDtos
{
    public class TeacherFileDto
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
