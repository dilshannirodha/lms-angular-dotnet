using backend.DTOs.UploadFilesDtos;
using backend.Services.UploadedFileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadedFilesController : ControllerBase
    {
        private readonly IUploadedFileService _service;

        public UploadedFilesController(IUploadedFileService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadFileDto dto)
        {
            var result = await _service.UploadAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var files = await _service.GetAllAsync();
            return Ok(files);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var fileResult = await _service.DownloadAsync(id);
            if (fileResult == null) return NotFound();
            return fileResult;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
