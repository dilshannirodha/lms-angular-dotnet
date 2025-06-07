using backend.DTOs.StudentFilesDtos;
using backend.DTOs.TeacherFileDtos;
using backend.Services.StudentFileServices;
using backend.Services.TeacherFileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherFilesController : ControllerBase
    {
        private readonly ITeacherFileService _service;

        public TeacherFilesController(ITeacherFileService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherFileDto>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherFileDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherFileDto>> Upload([FromForm] CreateTeacherFileDto dto)
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
