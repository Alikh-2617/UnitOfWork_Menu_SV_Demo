using DAL.Doman.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayMenuController : ControllerBase   // direct answer to request 
    {
        private readonly IUnitOfWork _context;

        public DayMenuController(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }

        [HttpPost("BreakFastMenu")]
        public async Task<IActionResult> BreakFastMenu(string day)
        {
            var menu = await _context.BreakFast.DayMenu(day);
            if (menu.Any())
            {
                return Ok(menu);

            }
            return NotFound();
        }

        [HttpPost("DinnerMenu")]
        public async Task<IActionResult> DinnerMenu(string day)
        {
            var menu = await _context.Dinner.DayMenu(day);
            if (menu.Any())
            {
                return Ok(menu);
            }
            return NotFound();
        }
        [HttpPost("DessertMenu")]
        public async Task<IActionResult> DessertMenu(string day)
        {
            var menu = await _context.Dessert.DayMenu(day);
            if (menu.Any())
            {
                return Ok(menu);
            }
            return NotFound();
        }
        [HttpPost("LunchMenu")]
        public async Task<IActionResult> LunchMenu(string day)
        {
            var menu = await _context.Lunch.DayMenu(day);
            if (menu.Any())
            {
                return Ok(menu);
            }
            return NotFound();
        }

    }
}
