namespace backend.DTOs.UploadFilesDtos
{
    public class UploadedFileDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

}
