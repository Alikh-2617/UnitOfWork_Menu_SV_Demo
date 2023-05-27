using MenuAPI.FilterConfiguration.AttributFilters;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileUploadController> _logger;

        public FileUploadController(IWebHostEnvironment webHostEnvironment, ILogger<FileUploadController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpPost("UploadFile")]
        [ServiceFilter(typeof(FileValidationAttribut))]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            string[] allowForm = { "image/png", "image/jpeg", "image/gif" };
            try
            {
                if(allowForm.Contains(file.ContentType))
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Pic\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok(file.FileName);
                    }
                }
                else
                {
                    return BadRequest("File not support !");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                return BadRequest("Object can not upload !");
            }
        }


        [HttpGet("GetFile")]
        public async Task<IActionResult> Get(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\Pic\\";
            var filePath = path + fileName;
            if (System.IO.File.Exists(filePath))
            {
                byte[] pic = System.IO.File.ReadAllBytes(filePath);
                return File(pic, "image/png");
            }
            return NotFound();
        }
    }
}
