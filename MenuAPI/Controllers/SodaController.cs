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
    public class SodaController : ControllerBase  // using direct Service 
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<SodaController> _logger;

        public SodaController(IUnitOfWork context , ILogger<SodaController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sodas = await _context.Soda.GetAll();
            if(sodas.Any())
            {
                return Ok(sodas);
            }
            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Drink_SodaVM soda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Soda sodaToCreate = new Soda();
                    sodaToCreate.Id = Guid.NewGuid();
                    sodaToCreate.Name = soda.Name;
                    sodaToCreate.Size = soda.Size;
                    await _context.Soda.insert(sodaToCreate);
                    await _context.save();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Object can not Create !");
                _logger.LogWarning($"{ex.Message}");
            }
        }
        [HttpGet("GetByid")]
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
            try
            {
                if (soda != null)
                {
                    _context.Soda.Update(soda);
                    await _context.save();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Object can not Update !");
                _logger.LogWarning($"{ex.Message}");
            }
        }
    }
}
