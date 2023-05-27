 using AutoMapper;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using MenuAPI.FilterConfiguration.AttributFilters;
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
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Dessert>))]
        public IActionResult GetDessert(Guid id)
        {
            var dessert = HttpContext.Items["entity"] as Dessert;
            return Ok(dessert);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(GenericVM dessertVM)
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
                _logger.LogWarning($"{ex.Message}");
                return NotFound("Object can not insert !");
            }
        }

        [HttpPost("DeleteById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Dessert>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dessert = HttpContext.Items["entity"] as Dessert;
            _context.Dessert.Delete(dessert!);
            await _context.save();  
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Dessert dessert) // can use like (Guid id , GenericVM food) 
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
                _logger.LogWarning($"{ex.Message}");
                return NotFound("Object can not update !");
            }
        }
    }
}
