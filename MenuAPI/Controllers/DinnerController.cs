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
    public class DinnerController : ControllerBase // use direct service
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<DinnerController> _logger;
        private readonly IMapper _mapper;

        public DinnerController(IUnitOfWork unitOfWork, ILogger<DinnerController> logger, IMapper mapper)
        {
            _context = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dinners = await _context.Dinner.GetAll();
            if (dinners.Any())
            {
                return Ok(dinners);
            }
            return NotFound();
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Dinner>))]
        public IActionResult GetDinner(Guid id)
        {
            var dinner = HttpContext.Items["entity"] as Dinner;
            return Ok(dinner);
        }

        [HttpPost("DeleteById")]
        [ServiceFilter(typeof(ValidationActionFilterAttribut<Dinner>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dessert = HttpContext.Items["entity"] as Dinner;
            _context.Dinner.Delete(dessert!);
            await _context.save();
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(GenericVM food)
        {
            try
            {
                var dinner = _mapper.Map<Dinner>(food);
                await _context.Dinner.insert(dinner);
                await _context.save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Object can not Create!");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(Dinner dinner)  // can use like (Guid id , GenericVM food) 
        {
            try
            {
                dinner.Update = DateTime.Now;
                _context.Dinner.Update(dinner);
                await _context.save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}");
                return BadRequest("Object can not Update!");
            }
        }

    }
}
