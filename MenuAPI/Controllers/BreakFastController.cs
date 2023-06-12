using AutoMapper;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using MenuAPI.FilterConfiguration.AttributFilters;
using MenuAPI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakFastController : ControllerBase    //use Json Converter and direkt mappning
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<BreakFastController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BreakFastController(IUnitOfWork unitOfWork, ILogger<BreakFastController> logger, IMapper mapper , IWebHostEnvironment webHostEnvironment)
        {
            _context = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var breateFast = await _context.BreakFast.GetAll();
            if (breateFast.Any())
            {
                return Ok(breateFast);
            }
            return NotFound();
        }
        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<BreakFast>))]
        public async Task<IActionResult> GetBreakFast(Guid id)
        {
            var breakfast = HttpContext.Items["entity"] as BreakFast;
            return Ok(breakfast);
        }

        [HttpPost("DeleteById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<BreakFast>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var breaFast = HttpContext.Items["entity"] as BreakFast;
            _context.BreakFast.Delete(breaFast!);
            await _context.save();
            return Ok();
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] GenericVM model)
        {
            try
            {
                model.ImageName = await SaveImage(model.Image);
                var BF = _mapper.Map<BreakFast>(model);  // exampel 
                await _context.BreakFast.insert(BF);
                await _context.save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Object can not insert !");
            }
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<BreakFast>))]
        public async Task<IActionResult> Update(JsonObject breakFast)
        {
            try
            {
                string objekt = breakFast.ToString()!;
                BreakFast BF = JsonConvert.DeserializeObject<BreakFast>(objekt)!;
                BF.Update = DateTime.Now;
                _context.BreakFast.Update(BF);
                await _context.save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Object can not update !");
            }
        }

        [NonAction]
        public async Task<string> SaveImage (IFormFile image)
        {
            // för att kunna ha unika name för bilder
            string imageName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(' ','-');
            imageName = imageName + DateTime.Now.ToString("yymmss") + Path.GetExtension(image.FileName);
            var imagePath = _webHostEnvironment.WebRootPath + "\\Pic\\";

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            using (FileStream fileStream = System.IO.File.Create(imagePath + imageName))
            {
                await image.CopyToAsync(fileStream);
                fileStream.Flush();
                return imageName;
            }
        }
    }
}
