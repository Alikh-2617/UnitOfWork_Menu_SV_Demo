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
    public class LunchController : ControllerBase  // using JsonConvert.DeserializeObject and direct mapping in controller
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<LunchController> _logger;

        public LunchController(IUnitOfWork context , ILogger<LunchController> logger )
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var luches =await _context.Lunch.GetAll();
            if (luches.Any())
            {
                return Ok(luches);
            }
            return NotFound();
        }

        [HttpGet("GetByid")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Lunch>))]
        public IActionResult GetLunch(Guid id)
        {
            var lunch = HttpContext.Items["entity"] as Lunch;
            return Ok(lunch);
        }

        [HttpPost("DeleteById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Lunch>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var lunch = HttpContext.Items["entity"] as Lunch;
            _context.Lunch.Delete(lunch);
            await _context.save();
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(JsonObject _lunch)
        {
            try
            {
                string Jsonobjekt = _lunch.ToString()!;
                GenericVM objekt = JsonConvert.DeserializeObject<GenericVM>(Jsonobjekt)!;
                if (objekt != null)
                {
                    Lunch lunch = new Lunch();
                    lunch.Id = Guid.NewGuid();
                    lunch.Name = objekt.Name;
                    lunch.Description = objekt.Description;
                    lunch.Create = DateTime.Now;
                    lunch.Day = objekt?.Day;
                    await _context.Lunch.insert(lunch);
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

        [HttpPut]
        public async Task<IActionResult> Update(JsonObject lunch)  // can use like (Guid id , GenericVM food) 
        {
            try
            {
                string objekt = lunch.ToString()!;
                Lunch objektToUpdate = JsonConvert.DeserializeObject<Lunch>(objekt!)!;
                if (objektToUpdate != null)
                {
                    Lunch lunchSave = new Lunch();
                    lunchSave.Id = objektToUpdate.Id;
                    lunchSave.Name = objektToUpdate.Name;
                    lunchSave.Description = objektToUpdate.Description;
                    lunchSave.Create = objektToUpdate.Create;
                    lunchSave.Update = DateTime.Now;
                    lunchSave.Day = objektToUpdate?.Day;
                    _context.Lunch.Update(lunchSave);
                    await _context.save();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Object can not update !");
                _logger.LogWarning($"{ex.Message}");
            }
        }
    }
}
