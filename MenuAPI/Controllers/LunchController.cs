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
    public class LunchController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public LunchController(IUnitOfWork context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var luches =await _context.Lunch.GetAll();
            return Ok(luches);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(GenericVM lunch)
        {
            string objekt = lunch.ToString()!;
            GenericVM objektToCreate = JsonConvert.DeserializeObject<GenericVM>(objekt!)!;
            if (objektToCreate != null)
            {
                Lunch lunchToCreate = new Lunch();
                lunchToCreate.Id = Guid.NewGuid();
                lunchToCreate.Name = objektToCreate.Name;
                lunchToCreate.Discription = objektToCreate.Description;
                lunchToCreate.Create = DateTime.Now;
                if (objektToCreate.Day != null) { lunchToCreate.Day = objektToCreate.Day; }
                await _context.Lunch.insert(lunchToCreate);
                await _context.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("{GetByid}")]
        public async Task<IActionResult> GetLunch(Guid id)
        { 
            var lunch = await _context.Lunch.Find(id);
            if (lunch != null)
            {
                Lunch lunch1 = new Lunch();
                lunch1.Id = lunch.Id;
                lunch1.Name = lunch.Name;
                lunch1.Discription = lunch.Discription;
                lunch1.Create = DateTime.Now;
                lunch1.Update = lunch.Update;
                return Ok(lunch1);
            }
            return NotFound();
        }
        [HttpPost("{deleteById}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var lunch =await _context.Lunch.Find(id);
            if (lunch != null)
            {
                _context.Lunch.Delete(lunch);
                await _context.save();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Lunch lunch)
        {
            string objekt = lunch.ToString()!;
            Lunch objektToUpdate = JsonConvert.DeserializeObject<Lunch>(objekt!)!;
            var lunchInDatabase =await _context.Lunch.Find(objektToUpdate.Id);
            if (lunchInDatabase != null)
            {
                Lunch lunchSave = new Lunch();  
                lunchSave.Id = lunchInDatabase.Id;
                lunchSave.Name = lunchInDatabase.Name;
                lunchSave.Discription = lunchInDatabase.Discription;
                lunchSave.Create = lunchInDatabase.Create;
                lunchSave.Update = DateTime.Now;
                if(lunchInDatabase.Day != null) { lunchSave.Day = lunchInDatabase.Day; }
                _context.Lunch.Update(lunchSave);
                return Ok();
            }
            return NotFound();
        }
    }
}
