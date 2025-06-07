using backend.DTOs.TeacherDtos;
using backend.Services.TeacherServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {

        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherResponseDto>>> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpGet("{teacherId}")]
        public async Task<ActionResult<TeacherResponseDto>> GetTeacherById(string teacherId)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
            return teacher == null ? NotFound() : Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherResponseDto>> CreateTeacher(CreateTeacherDto createDto)
        {
            var teacher = await _teacherService.CreateTeacherAsync(createDto);
            return CreatedAtAction(nameof(GetTeacherById), new { teacherId = teacher.TeacherId }, teacher);
        }

        [HttpPut("{teacherId}")]
        public async Task<ActionResult<TeacherResponseDto>> UpdateTeacher(string teacherId, UpdateTeacherDto updateDto)
        {
            var teacher = await _teacherService.UpdateTeacherAsync(teacherId, updateDto);
            return teacher == null ? NotFound() : Ok(teacher);
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> DeleteTeacher(string teacherId)
        {
            var result = await _teacherService.DeleteTeacherAsync(teacherId);
            return result ? NoContent() : NotFound();
        }
    }
}
