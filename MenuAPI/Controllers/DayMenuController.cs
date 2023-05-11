using DAL.Doman.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayMenuController : ControllerBase
    {
        private IUnitOfWork _context;

        public DayMenuController(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }

        [HttpPost("BreakFastMenu")]
        public async Task<IActionResult> BreakFastMenu(string day)
        {
            var day1 = await _context.BreakFast.DayMenu(day);
            if (day1 != null)
            {
                return Ok(day1);
            }
            return NotFound();
        }

        [HttpPost("DinnerMenu")]
        public async Task<IActionResult> DinnerMenu(string day)
        {
            var day1 = await _context.Dinner.DayMenu(day);
            if (day1 != null)
            {
                return Ok(day1);
            }
            return NotFound();
        }
        [HttpPost("DessertMenu")]
        public async Task<IActionResult> DessertMenu(string day)
        {
            var day1 = await _context.Dessert.DayMenu(day);
            if (day1 != null)
            {
                return Ok(day1);
            }
            return NotFound();
        }
        [HttpPost("LunchMenu")]
        public async Task<IActionResult> LunchMenu(string day)
        {
            var day1 = await _context.Lunch.DayMenu(day);
            if (day1 != null)
            {
                return Ok(day1);
            }
            return NotFound();
        }

    }
}
