using FestivalApi.Models;
using FestivaLApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FestivalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        public List<Stage> stages = new List<Stage>{
            new Stage { Id = 1, Name = "Stora Scenen" },
            new Stage { Id = 2, Name = "Mellan Scenen" },
            new Stage { Id = 3, Name = "Den hyffsat stora Scenen" },
            new Stage { Id = 4, Name = "Knatte Scenen" }
        };

        [HttpGet]
        public ActionResult<List<Stage>> GetAllStages()
        {
            if (stages == null || !stages.Any())
            {
                return NotFound();
            }

            return Ok(stages.Select(a => a.Name));
        }

        [HttpGet("{id}")]
        public ActionResult<Stage> GetStageById([FromRoute] int id)
        {
            var stage = stages.FirstOrDefault(s => s.Id == id);

            if (stage == null)
            {
                return NotFound();
            }

            return Ok(stage.Name);
        }

        [HttpPost]
        public ActionResult<Stage> CreateNewStage([FromBody] Stage stage)
        {
            if (stage == null)
            {
                return BadRequest();
            }

            Stage nameCheck = stages.FirstOrDefault(s => s.Name == stage.Name);

            if (nameCheck != null)
            {
                return BadRequest();
            }
            stages.Add(new Stage { Id = (stages.Last().Id + 1), Name = stage.Name });
            return Created();
        }

        [HttpPut]
        public ActionResult<Stage> ChangeStageNameById([FromBody] Stage newStage)
        {
            if (newStage == null)
            {
                return BadRequest();
            }
            Stage stageToBeEdited = stages.FirstOrDefault(s => s.Id == newStage.Id);
            if (stageToBeEdited == null)
            {
                return NotFound();
            }
            stageToBeEdited.Name = newStage.Name;
            return Ok(stages);
        }
        [HttpDelete("{id}")]
        public ActionResult<Stage> DeleteStageById(int id)
        {
            var stageToBeremoved = stages.FirstOrDefault(s => s.Id == id);

            if (stageToBeremoved == null)
            {
                return NotFound();
            }

            stages.Remove(stageToBeremoved);

            return Ok(stages);
        }
    }
}
