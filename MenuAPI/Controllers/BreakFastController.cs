using AutoMapper;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using MenuAPI.FilterConfiguration.AttributFilters;
using MenuAPI.ViewModels;
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

        public BreakFastController(IUnitOfWork unitOfWork, ILogger<BreakFastController> logger, IMapper mapper)
        {
            _context = unitOfWork;
            _logger = logger;
            _mapper = mapper;
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


        [HttpPost("Create")]
        public async Task<IActionResult> Create(JsonObject breakFast)
        {
            try
            {
                string objekt = breakFast.ToString()!;
                GenericVM objektToCreate = JsonConvert.DeserializeObject<GenericVM>(objekt)!;
                var BF = _mapper.Map<BreakFast>(breakFast);  // exampel 
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
        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<BreakFast>))]
        public IActionResult GetBreakFast(Guid id)
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
        [HttpPut]
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

    }
}
