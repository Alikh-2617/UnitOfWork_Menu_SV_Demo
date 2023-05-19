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
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DessertController> _logger;

        public DessertController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DessertController> logger)
        {
            _context = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dessert = await _context.Dessert.GetAll();
            if (dessert.Any())
            {
                return Ok(dessert);
            }
            return NotFound();
        }



        [HttpGet("GetById")]
        public async Task<IActionResult> GetDessert(Guid id)
        {
            var dessert = await _context.Dessert.Find(id);
            if (dessert != null)
            {
                return Ok(dessert);
            }
            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(GenericVM dessertVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dessert = _mapper.Map<Dessert>(dessertVM);
                    await _context.Dessert.insert(dessert);
                    await _context.save();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound("Object can not insert !");
                    _logger.LogWarning($"{ex.Message}");
                }
            }
            return BadRequest();
        }

        [HttpPost("DeleteById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var objekt = await _context.Dessert.Find(id);
            if (objekt != null)
            {
                _context.Dessert.Delete(objekt);
                await _context.save();
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Dessert dessert) // can use like (Guid id , GenericVM food) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dessert.Update = DateTime.Now;
                    _context.Dessert.Update(dessert);
                    await _context.save();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound("Object can not update !");
                    _logger.LogWarning($"{ex.Message}");
                }
            }
            return BadRequest();
        }
    }
}
