using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/students/{studentId}/[controller]")]
    public class StudentUploadsController : ControllerBase
    {
        private readonly IStudentUploadService _uploadService;

        public StudentUploadsController(IStudentUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentUploadResponseDto>>> GetAllStudentUploads(string studentId)
        {
            var uploads = await _uploadService.GetAllStudentUploadsAsync(studentId);
            return Ok(uploads);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentUploadResponseDto>> GetStudentUploadById(int id)
        {
            var upload = await _uploadService.GetStudentUploadByIdAsync(id);
            return upload == null ? NotFound() : Ok(upload);
        }

        [HttpPost]
        public async Task<ActionResult<StudentUploadResponseDto>> CreateStudentUpload(
            string studentId,
            CreateStudentUploadDto createDto)
        {
            createDto.StudentId = studentId;
            var upload = await _uploadService.CreateStudentUploadAsync(createDto);
            return CreatedAtAction(nameof(GetStudentUploadById), new { studentId, id = upload.Id }, upload);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentUploadResponseDto>> UpdateStudentUpload(
            int id,
            UpdateStudentUploadDto updateDto)
        {
            var upload = await _uploadService.UpdateStudentUploadAsync(id, updateDto);
            return upload == null ? NotFound() : Ok(upload);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentUpload(int id)
        {
            var result = await _uploadService.DeleteStudentUploadAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
