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


    }
}
