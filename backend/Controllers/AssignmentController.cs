using backend.DTOs.AssignmentDtos;
using backend.Services.AssignmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _service;

        public AssignmentController(IAssignmentService service)
        {
            _service = service;
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourseId(string courseId)
        {
            var assignments = await _service.GetAssignmentsByCourseIdAsync(courseId);
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var assignment = await _service.GetAssignmentByIdAsync(id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssignmentDto createDto)
        {
            var created = await _service.CreateAssignmentAsync(createDto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAssignmentDto updateDto)
        {
            var updated = await _service.UpdateAssignmentAsync(id, updateDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAssignmentAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
