using AutoMapper;
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
    public class DessertController : ControllerBase  // med Auto Mapper mappning  paket Auto mapper , lägga till i program.cs
    {
        private IUnitOfWork _context;
        private IMapper _mapper;

        public DessertController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _context = unitOfWork;
            _mapper = mapper;
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
            if(ModelState.IsValid)
            {
                var dessert = _mapper.Map<Dessert>(dessertVM);
                await _context.Dessert.insert(dessert);
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
            if(ModelState.IsValid)
            {
                var dessertInDatabase = await _context.Dessert.Find(dessert.Id);
                if(dessertInDatabase != null)
                {
                    var dessertToSave = _mapper.Map<Dessert>(dessert);
                    _context.Dessert.Update(dessertToSave);
                    await _context.save();
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
