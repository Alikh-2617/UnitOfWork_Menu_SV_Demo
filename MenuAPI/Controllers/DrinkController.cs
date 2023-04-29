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
    public class DrinkController : ControllerBase   
    {
        private readonly IUnitOfWork _context;

        public DrinkController(IUnitOfWork context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Drinks = await _context.Drink.GetAll();
            return Ok(Drinks);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Drink_SodaVM drink)
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
        [HttpGet("{GetByid}")]
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
        [HttpPost("{deleteById}")]
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
    }
}
