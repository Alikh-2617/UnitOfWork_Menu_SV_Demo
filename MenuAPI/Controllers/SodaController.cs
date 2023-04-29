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
    public class SodaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public SodaController(IUnitOfWork context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sodas = await _context.Soda.GetAll();
            return Ok(sodas);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Drink_SodaVM soda)
        {
            string objekt = soda.ToString()!;
            Drink_SodaVM objektToCreate = JsonConvert.DeserializeObject<Drink_SodaVM>(objekt!)!;
            if (objektToCreate != null)
            {
                Soda sodaToCreate = new Soda();
                sodaToCreate.Id = Guid.NewGuid();
                sodaToCreate.Name = objektToCreate.Name;
                sodaToCreate.Size = objektToCreate.Size;
                await _context.Soda.insert(sodaToCreate);
                await _context.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("{GetByid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var sodaInDatabase = await _context.Soda.Find(id);
            if (sodaInDatabase != null)
            {
                Soda soda = new Soda();
                soda.Id = sodaInDatabase.Id;
                soda.Name = sodaInDatabase.Name;
                soda.Size = sodaInDatabase.Size;
                return Ok(soda);
            }
            return NotFound();
        }
        [HttpPost("{deleteById}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var soda = await _context.Soda.Find(id);
            if (soda != null)
            {
                _context.Soda.Delete(soda);
                await _context.save();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Soda soda)
        {
            string objekt = soda.ToString()!;
            Soda objektToUpdate = JsonConvert.DeserializeObject<Soda>(objekt!)!;
            var sodaInDatabase =await _context.Soda.Find(objektToUpdate.Id);
            if (sodaInDatabase != null)
            {
                Soda sodaSave = new Soda();
                sodaSave.Id = objektToUpdate.Id;
                sodaSave.Name = objektToUpdate.Name;
                sodaSave.Size = objektToUpdate.Size;
                _context.Soda.Update(sodaSave);
                return Ok();
            }
            return NotFound();
        }
    }
}
