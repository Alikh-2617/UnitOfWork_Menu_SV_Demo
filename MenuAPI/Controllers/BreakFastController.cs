using AutoMapper;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using MenuAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakFastController : ControllerBase    //use Json Converter and direkt mappning
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<BreakFastController> _logger;

        public BreakFastController(IUnitOfWork unitOfWork, ILogger<BreakFastController> logger )
        {
            _context = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var breateFast = await _context.BreakFast.GetAll();
            if(breateFast.Any())
            {
                return Ok(breateFast);
            }
            return NotFound();
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(JsonObject breakFast)
        {
            try
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
                    breakFastToCreate.Day = objektToCreate?.Day; 
                    await _context.BreakFast.insert(breakFastToCreate);
                    await _context.save();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Object can not insert !");
                _logger.LogWarning($"{ex.Message}");
            }
        }
        [HttpGet("GetById")]
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
                await _context.save();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(JsonObject breakFast)
        {
            try
            {
                string objekt = breakFast.ToString()!;
                BreakFast objektToUpdate = JsonConvert.DeserializeObject<BreakFast>(objekt)!;
                if (objektToUpdate != null)
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
            catch (Exception ex)
            {
                return BadRequest("Onject can not update !");
                _logger.LogWarning($"{ex.Message}");
            }
        }

    }
}
