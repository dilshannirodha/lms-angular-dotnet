using backend.DTOs.StudentFilesDtos;
using backend.Services.StudentFileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentFilesController : ControllerBase
    {
        private readonly IStudentFileService _service;

        public StudentFilesController(IStudentFileService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentFileDto>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentFileDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<StudentFileDto>> Upload([FromForm] CreateStudentFileDto dto)
        {
            var uploaded = await _service.UploadAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = uploaded.Id }, uploaded);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }

}
