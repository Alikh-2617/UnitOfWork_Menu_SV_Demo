using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using MenuAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase  // using JsonConvert.DeserializeObject
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(IUnitOfWork context , ILogger<DrinkController> logger)
        {
            _context = context;
            _logger = logger;
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

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Drink_SodaVM drink)
        {
            try
            {
                string objekt = drink.ToString()!;
                Drink_SodaVM objektToCreate = JsonConvert.DeserializeObject<Drink_SodaVM>(objekt!)!;
                if (objektToCreate != null)
                {
                    Drink drinkToCreate = new Drink();
                    drinkToCreate.Id = Guid.NewGuid();
                    drinkToCreate.Name = objektToCreate.Name;
                    drinkToCreate.Size = objektToCreate.Size;
                    await _context.Drink.insert(drinkToCreate);
                    await _context.save();
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception ex) 
            {
                return BadRequest("Onject can not Create");
                _logger.LogWarning($"{ex.Message}");
            }
        }
        [HttpGet("GetByid")]
        public async Task<IActionResult> Get(Guid id)
        {
            var drinkInDatabase = await _context.Drink.Find(id);
            if (drinkInDatabase != null)
            {
                Drink drink = new Drink();
                drink.Id = drinkInDatabase.Id;
                drink.Name = drinkInDatabase.Name;
                drink.Size = drinkInDatabase.Size;
                return Ok(drink);
            }
            return NotFound();
        }
        [HttpPost("DeleteById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var drink = await _context.Drink.Find(id);
            if (drink != null)
            {
                _context.Drink.Delete(drink);
                await _context.save();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Drink drink)
        {
            try
            {
                string objekt = drink.ToString()!;
                Drink objektToUpdate = JsonConvert.DeserializeObject<Drink>(objekt!)!;
                var drinkInDatabase = await _context.Lunch.Find(objektToUpdate.Id);
                if (drinkInDatabase != null)
                {
                    Drink dringSave = new Drink();
                    dringSave.Id = objektToUpdate.Id;
                    dringSave.Name = objektToUpdate.Name;
                    dringSave.Size = objektToUpdate.Size;
                    _context.Drink.Update(dringSave);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Object can not Update .");
                _logger.LogWarning($"{ex.Message}");
            }
        }
    }
}
