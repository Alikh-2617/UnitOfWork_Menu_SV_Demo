using MenuAPI.FilterConfiguration.AttributFilters;
using MenuAPI.Service;
using MenuAPI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;


namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger<FileUploadController> _logger;
        private readonly UploadService _service;

        public FileUploadController( ILogger<FileUploadController> logger , UploadService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("UploadFile")]
        [ServiceFilter(typeof(FileValidationAttribut))]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(_service.upload(file, out string filename))
            {
                return Ok(filename);
            }
            _logger.LogInformation("Something wrong with upload !");
            return BadRequest("Object Can not upload !");
        }

        [HttpGet("GetFile")]
        public async Task<IActionResult> Get(string fileName)
        {
            if(_service.download(fileName , out byte[] file))
            {
                return File(file, "image/png");
            }
            _logger.LogInformation("Something wrong with download !");
            return NotFound("Object has not any image !");
        }
    }
}
