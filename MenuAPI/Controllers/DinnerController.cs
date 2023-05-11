using AutoMapper;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using MenuAPI.FilterConfiguration.AttributFilters;
using MenuAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinnerController : ControllerBase //using IMapp 
    {
        private IUnitOfWork _context;
        private IMapper _mapper;

        public DinnerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ActionFilterAttribut("somting")]

        public async Task<IActionResult> Get()
        {
            var dinners = await _context.Dinner.GetAll();
            return Ok(dinners);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(GenericVM food)
        {
            if(ModelState.IsValid)
            {
                var dinnerToCreate = _mapper.Map<Dinner>(food);
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
                Dinner dinnerSave = _mapper.Map<Dinner>(objektToUpdate);
                dinnerSave.Update = DateTime.Now;
                _context.Dinner.Update(dinnerSave);
                await _context.save();

            }
            return BadRequest();        
        }

    }
}
