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
    public class DessertController : ControllerBase  // med Auto Mapper mappning 
    {
        private IUnitOfWork _context;

        public DessertController(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dessert = await _context.Dessert.GetAll();
            return Ok(dessert);
        }
        [HttpGet("{getById}")]
        public async Task<IActionResult> GetDessert(Guid id)
        {
            var dessert = await _context.Dessert.Find(id);
            if(dessert != null) 
            {
                return Ok(dessert); 
            }
            return NotFound();  
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(GenericVM dessertVM)
        {
            string objekt = dessertVM.ToString()!;
            GenericVM dessert = JsonConvert.DeserializeObject<GenericVM>(objekt!)!;   
            if(dessert != null)
            {
                Dessert dessertToCreate = new Dessert();
                dessertToCreate.Id = Guid.NewGuid();
                dessertToCreate.Name = dessert.Name;
                dessertToCreate.Description = dessert.Description;
                dessertToCreate.Create = DateTime.Now;
                if(dessert.Day != null) { dessertToCreate.Day = dessert.Day; }
                await _context.Dessert.insert(dessertToCreate);
                await _context.save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("deleteById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var objekt = await _context.Dessert.Find(id);
            if(objekt != null)
            {
                _context.Dessert.Delete(objekt);
                await _context.save();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Dessert dessert)
        {
            string objekt = dessert.ToString()!;
            Dessert objektToUpdate = JsonConvert.DeserializeObject<Dessert>(objekt)!;
            var dessertInDatabase = await _context.Dessert.Find(objektToUpdate.Id);
            if(dessertInDatabase != null)
            {
                Dessert dessertSave = new Dessert();
                dessertSave.Id = objektToUpdate.Id;
                dessertSave.Name = objektToUpdate.Name;
                dessertSave.Description = objektToUpdate.Description;
                dessertSave.Create = objektToUpdate.Create;
                dessertSave.Update = DateTime.Now;
                if(objektToUpdate.Day != null) { dessertSave.Day =  objektToUpdate.Day; }
                _context.Dessert.Update(dessertSave);
                await _context.save();
                return Ok();
            }
            return BadRequest();
        }
    }
}
