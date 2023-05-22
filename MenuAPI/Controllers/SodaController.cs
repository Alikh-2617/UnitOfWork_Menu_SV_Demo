using AutoMapper;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using MenuAPI.FilterConfiguration.AttributFilters;
using MenuAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SodaController : ControllerBase  // using direct Service 
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<SodaController> _logger;
        private readonly IMapper _mapper;

        public SodaController(IUnitOfWork context, ILogger<SodaController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sodas = await _context.Soda.GetAll();
            if (sodas.Any())
            {
                return Ok(sodas);
            }
            return NotFound();
        }


        [HttpGet("GetByid")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Soda>))]
        public async Task<IActionResult> Get(Guid id)
        {
            var sodaInDatabase = await _context.Soda.Find(id);
            if (sodaInDatabase != null)
            {
                return Ok(sodaInDatabase);
            }
            return NotFound();
        }

        [HttpPost("DeleteById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Soda>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var soda = HttpContext.Items["entity"] as Soda;
            _context.Soda.Delete(soda!);
            await _context.save();
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Drink_SodaVM soda)
        {
            try
            {
                var SF = _mapper.Map<Soda>(soda);
                await _context.Soda.insert(SF);
                await _context.save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Object can not Create !");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Soda soda)
        {
            try
            {
                _context.Soda.Update(soda);
                await _context.save();
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Object can not Update !");
            }
        }
    }
}
