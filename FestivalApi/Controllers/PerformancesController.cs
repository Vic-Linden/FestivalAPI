using Microsoft.AspNetCore.Mvc;
using FestivaLApi.Models;

namespace FestivalApi.Controllers
{
    [ApiController]
    [Route("api/performances")]
    public class PerformancesController : ControllerBase
    {
        List<Performance> performances = new List<Performance>
        {
            new Performance { Id = 1,  StartTime = new DateTime(2026, 8, 18, 16, 0, 0),  EndTime = new DateTime(2026, 8, 18, 16, 45, 0), Genre = "Pop / soul" },
            new Performance { Id = 2,  StartTime = new DateTime(2026, 8, 18, 16, 30, 0), EndTime = new DateTime(2026, 8, 18, 17, 15, 0), Genre = "Pop / elektronisk musik" },
            new Performance { Id = 3,  StartTime = new DateTime(2026, 8, 18, 17, 0, 0),  EndTime = new DateTime(2026, 8, 18, 17, 45, 0), Genre = "Pop / R&B" },
            new Performance { Id = 4,  StartTime = new DateTime(2026, 8, 18, 17, 30, 0), EndTime = new DateTime(2026, 8, 18, 18, 15, 0), Genre = "Pop" },
            new Performance { Id = 5,  StartTime = new DateTime(2026, 8, 18, 18, 0, 0),  EndTime = new DateTime(2026, 8, 18, 18, 45, 0), Genre = "Pop / singer-songwriter" },
            new Performance { Id = 6,  StartTime = new DateTime(2026, 8, 18, 18, 30, 0), EndTime = new DateTime(2026, 8, 18, 19, 15, 0), Genre = "Indiepop / alternativ pop" },
            new Performance { Id = 7,  StartTime = new DateTime(2026, 8, 18, 19, 0, 0),  EndTime = new DateTime(2026, 8, 18, 19, 45, 0), Genre = "Pop" },
            new Performance { Id = 8,  StartTime = new DateTime(2026, 8, 18, 19, 30, 0), EndTime = new DateTime(2026, 8, 18, 20, 15, 0), Genre = "Pop / soul" },
            new Performance { Id = 9,  StartTime = new DateTime(2026, 8, 18, 20, 0, 0),  EndTime = new DateTime(2026, 8, 18, 20, 50, 0), Genre = "Pop / soul / hiphop" },
            new Performance { Id = 10, StartTime = new DateTime(2026, 8, 18, 21, 0, 0),  EndTime = new DateTime(2026, 8, 18, 22, 0, 0), Genre = "Pop / R&B" }
        };

        [HttpGet]
        public ActionResult<List<Performance>> GetAllPerformances()
        {
            if (performances == null || !performances.Any())
            {
                return NotFound();
            }

            return Ok(performances);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Performance> GetPerformancesById([FromRoute] int id)
        {
            var performance = performances.FirstOrDefault(a => a.Id == id);

            if (performance == null)
            {
                return NotFound();
            }

            return Ok(performance);
        }

        [HttpPost]
        public ActionResult<Performance> CreatePerformance([FromBody] Performance newPerformance)
        {
            if (newPerformance.StartTime > newPerformance.EndTime || newPerformance.Genre is null)
            {
                return BadRequest();
            }
            int id = performances.Max(p => p.Id) + 1;

            newPerformance.Id = id;

            performances.Add(newPerformance);

            return Created();
        }

        [HttpPut("{id:int}")]
        public ActionResult<Performance> UpdatePerformanceById([FromBody] Performance updatedPerformance)
        {
            if (updatedPerformance.StartTime > updatedPerformance.EndTime || updatedPerformance.Genre is null)
            {
                return BadRequest();
            }

            Performance oldPerformance = performances.FirstOrDefault(p => p.Id == updatedPerformance.Id);

            oldPerformance.Id = updatedPerformance.Id;
            oldPerformance.StartTime = updatedPerformance.StartTime;
            oldPerformance.EndTime = updatedPerformance.EndTime;
            oldPerformance.Genre = updatedPerformance.Genre;
            

            return Ok(oldPerformance);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Performance> CreatePerformance([FromRoute] int id)
        {
            Performance toDelete = performances.FirstOrDefault(p => p.Id == id);
            if (toDelete is null)
            {
                return NotFound();
            }

            performances.Remove(toDelete);
            return Ok();
        }


    }

}