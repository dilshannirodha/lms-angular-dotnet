using backend.DTOs.StudentDtos;
using backend.Services.StudentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentResponseDto>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentResponseDto>> GetStudentById(string studentId)
        {
            var student = await _studentService.GetStudentByIdAsync(studentId);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> CreateStudent(CreateStudentDto createDto)
        {
            var student = await _studentService.CreateStudentAsync(createDto);
            return CreatedAtAction(nameof(GetStudentById), new { studentId = student.StudentId }, student);
        }

        [HttpPut("{studentId}")]
        public async Task<ActionResult<StudentResponseDto>> UpdateStudent(string studentId, UpdateStudentDto updateDto)
        {
            var student = await _studentService.UpdateStudentAsync(studentId, updateDto);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            var result = await _studentService.DeleteStudentAsync(studentId);
            return result ? NoContent() : NotFound();
        }
    }
}
