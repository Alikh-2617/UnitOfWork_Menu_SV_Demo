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
    public class DinnerController : ControllerBase // med implicit operator mappning in i View model class
    {
        private IUnitOfWork _context;

        public DinnerController(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dinners = await _context.Dinner.GetAll();
            return Ok(dinners);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(GenericVM dinner)
        {
            string objekt = dinner.ToString()!;
            GenericVM objektToCreate = JsonConvert.DeserializeObject<GenericVM>(objekt)!;
            if(objektToCreate != null)
            {
                Dinner dinnerToCreate = new Dinner();
                dinnerToCreate.Id = Guid.NewGuid();
                dinnerToCreate.Name = objektToCreate.Name;
                dinnerToCreate.Discription = objektToCreate.Description;
                dinnerToCreate.Created = DateTime.Now;
                if(objektToCreate.Day != null) { dinnerToCreate.Day = objektToCreate.Day; }
                await _context.Dinner.insert(dinnerToCreate);
                await _context.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public IActionResult GetDinner(Guid id)
        {
            var dinner = _context.Dinner.Find(id);
            if(dinner != null)
            {
                return Ok(dinner);
            }
            return NotFound();
        }

        [HttpPost("DeleteById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dinner = await _context.Dinner.Find(id);
            if(dinner != null)
            {
                _context.Dinner.Delete(dinner);
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Dinner dinner) 
        {
            string objekt = dinner.ToString()!;
            Dinner objektToUpdate = JsonConvert.DeserializeObject<Dinner>(objekt)!;
            var dinnerInDatabase = await _context.Dinner.Find(objektToUpdate.Id);
            if(dinnerInDatabase != null)
            {
                Dinner dinnerSave = new Dinner();
                dinnerSave.Id = objektToUpdate.Id;
                dinnerSave.Name = objektToUpdate.Name;
                dinnerSave.Discription = objektToUpdate.Discription;
                dinnerSave.Created = objektToUpdate.Created;
                dinnerSave.Update = DateTime.Now;
                if(objektToUpdate.Day != null) { dinnerSave.Day =  objektToUpdate.Day; }
                _context.Dinner.Update(dinnerSave);
                await _context.save();

            }
            return BadRequest();        
        }

    }
}
