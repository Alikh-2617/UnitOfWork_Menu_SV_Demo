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
    public class DrinkController : ControllerBase  // using JsonConvert.DeserializeObject
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<DrinkController> _logger;
        private readonly IMapper _mapper;

        public DrinkController(IUnitOfWork context, ILogger<DrinkController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var drinks = await _context.Drink.GetAll();
            if (drinks.Any())
            {
                return Ok(drinks);
            }
            return NotFound();
        }

        [HttpGet("GetByid")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Drink>))]
        public IActionResult Get(Guid id)
        {
            var drink = HttpContext.Items["entity"] as Drink;
            return Ok(drink);
        }

        [HttpPost("DeleteById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Drink>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var drink = HttpContext.Items["entity"] as Drink;
            _context.Drink.Delete(drink!);
            await _context.save();
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Drink_SodaVM drink)
        {
            try
            {
                //string objekt = drink.ToString()!;
                //Drink_SodaVM drinke = JsonConvert.DeserializeObject<Drink_SodaVM>(objekt)!;
                var DF = _mapper.Map<Drink>(drink);
                await _context.Drink.insert(DF);
                await _context.save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Onject can not Create");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Drink drink)
        {
            try
            {
                //string objekt = drink.ToString()!;
                //Drink objektToUpdate = JsonConvert.DeserializeObject<Drink>(objekt!)!;

                _context.Drink.Update(drink);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Object can not Update .");
            }
        }
    }
}
