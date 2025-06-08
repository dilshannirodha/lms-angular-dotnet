using backend.DTOs.NotificationDtos;
using backend.Services.NotificationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationsController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notifications = await _service.GetAllAsync();
            return Ok(notifications);
        }

        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetByUser(string username)
        {
            var notifications = await _service.GetByUserAsync(username);
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { message = "Notification created." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
