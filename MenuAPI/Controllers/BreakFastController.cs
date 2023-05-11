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
    public class BreakFastController : ControllerBase    // direkt mappning
    {
        private IUnitOfWork _context;

        public BreakFastController(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var breateFast = await _context.BreakFast.GetAll();
            return Ok(breateFast);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(GenericVM breakFast)
        {
            string objekt = breakFast.ToString()!;
            GenericVM objektToCreate = JsonConvert.DeserializeObject<GenericVM>(objekt)!;
            if (objektToCreate != null)
            {
                BreakFast breakFastToCreate = new BreakFast();
                breakFastToCreate.Id = Guid.NewGuid();
                breakFastToCreate.Name = objektToCreate.Name;
                breakFastToCreate.Description = objektToCreate.Description;
                breakFastToCreate.Create = DateTime.Now;
                if (objektToCreate.Day != null) { breakFastToCreate.Day = objektToCreate.Day; }
                await _context.BreakFast.insert(breakFastToCreate);
                await _context.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetBreakFast(Guid id)
        {
            var breakFast = await _context.BreakFast.Find(id);
            if (breakFast != null)
            {
                return Ok(breakFast);
            }
            return NotFound();
        }

        [HttpPost("DeleteById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var breaFast = await _context.BreakFast.Find(id);
            if (breaFast != null)
            {
                _context.BreakFast.Delete(breaFast);
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(BreakFast breakFast)
        {
            string objekt = breakFast.ToString()!;
            BreakFast objektToUpdate = JsonConvert.DeserializeObject<BreakFast>(objekt)!;
            var breakFastToUpdate = _context.BreakFast.Find(objektToUpdate.Id);
            if (breakFastToUpdate != null)
            {
                BreakFast breakFastSave = new BreakFast();
                breakFastSave.Id = objektToUpdate.Id;
                breakFastSave.Name = objektToUpdate.Name;
                breakFastSave.Description = objektToUpdate.Description;
                breakFastSave.Create = objektToUpdate.Create;
                breakFastSave.Update = DateTime.Now;
                if (objektToUpdate.Day != null) { breakFastSave.Day = objektToUpdate.Day; }
                _context.BreakFast.Update(breakFastSave);
                await _context.save();
                return Ok();

            }
            return BadRequest();
        }

    }
}
