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

        public DinnerController(IUnitOfWork unitOfWork , ILogger<DinnerController> logger)
        {
            _context = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        [ActionFilterAttribut]

        public async Task<IActionResult> Get()
        {
            var dinners = await _context.Dinner.GetAll();
            if (dinners.Any())
            {
                return Ok(dinners);
            }
            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(GenericVM food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Dinner _dinner = new Dinner();
                    _dinner.Id = Guid.NewGuid();
                    _dinner.Name = food.Name;
                    _dinner.Discription = food.Description;
                    _dinner.Created = DateTime.UtcNow;
                    _dinner.Day = food.Day ?? string.Empty;
                    await _context.Dinner.insert(_dinner);
                    await _context.save();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Object can not Create!");
                _logger.LogWarning($"{ex.Message}");
            }
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetDinner(Guid id)
        {
            var dinner =await _context.Dinner.Find(id);
            if (dinner != null)
            {
                return Ok(dinner);
            }
            return NotFound();
        }

        [HttpPost("DeleteById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dinner = await _context.Dinner.Find(id);
            if (dinner != null)
            {
                _context.Dinner.Delete(dinner);
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Dinner dinner)  // can use like (Guid id , GenericVM food) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dinner.Update = DateTime.Now;
                    _context.Dinner.Update(dinner);
                    await _context.save();
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest("Object can not Update!");
                _logger.LogWarning($"{ex.Message}");
            }
        }

    }
}
