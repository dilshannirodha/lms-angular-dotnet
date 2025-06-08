using backend.DTOs.StudentEnrollmentDtos;
using backend.DTOs.TeacherEnrollmentDtos;
using backend.Services.StudentEnrollmentServices;
using backend.Services.TeacherEnrollmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/teacher-enrollments")]
    [ApiController]
    public class TeacherEnrollmentController : ControllerBase
    {
        private readonly ITeacherEnrollmentService _service;

        public TeacherEnrollmentController(ITeacherEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherEnrollmentDto>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherEnrollmentDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherEnrollmentDto>> Create(CreateTeacherEnrollmentDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherEnrollmentDto>> Update(int id, CreateTeacherEnrollmentDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("teacher/{teacherId}/course-ids")]
        public async Task<IActionResult> GetCourseIdsByTeacherId(string teacherId)
        {
            var result = await _service.GetCourseIdsByTeacherIdAsync(teacherId);
            return Ok(result);
        }
    }
}
