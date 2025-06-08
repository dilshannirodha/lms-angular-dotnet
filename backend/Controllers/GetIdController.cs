using backend.DTOs.GetId;
using backend.Services.GetIdService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetIdController : ControllerBase
    {
        private readonly IGetIdService _userIdService;

        public GetIdController(IGetIdService userIdService)
        {
            _userIdService = userIdService;
        }

        [HttpGet("student/{username}")]
        public async Task<ActionResult<GetIdByUsernameResponse>> GetStudentId(string username)
        {
            var id = await _userIdService.GetStudentIdByUsernameAsync(username);
            if (id == null) return NotFound($"Student with username '{username}' not found.");
            return Ok(new GetIdByUsernameResponse { Id = id });
        }

        [HttpGet("teacher/{username}")]
        public async Task<ActionResult<GetIdByUsernameResponse>> GetTeacherId(string username)
        {
            var id = await _userIdService.GetTeacherIdByUsernameAsync(username);
            if (id == null) return NotFound($"Teacher with username '{username}' not found.");
            return Ok(new GetIdByUsernameResponse { Id = id });
        }
    }
}
