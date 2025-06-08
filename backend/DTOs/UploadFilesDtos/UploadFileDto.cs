namespace backend.DTOs.UploadFilesDtos
{
    public class UploadFileDto
    {
        public string Username { get; set; } = string.Empty;
        public IFormFile File { get; set; } = null!;
    }

}
