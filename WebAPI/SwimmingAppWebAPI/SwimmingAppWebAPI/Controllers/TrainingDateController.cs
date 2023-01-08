using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.BL.Managers.TrainingDateManager;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("training_date")]
    [ApiController]
    public class TrainingDateController : Controller
    {
        private readonly TrainingDateManager _trainingDateManager;

        public TrainingDateController(TrainingDateManager trainingDateManager)
        {
            _trainingDateManager = trainingDateManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTrainingDate()
        {
            try
            {
                var userID = HttpContext?.User.Claims.Where(x => x.Type == "UserID").Single();
                var result = await _trainingDateManager.GetTrainingDate(int.Parse(userID.Value));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertTrainingDate(List<TrainingDateDTO> trainingDateDTO)
        {
            try
            {
                var userID = HttpContext?.User.Claims.Where(x => x.Type == "UserID").Single();
                var result = await _trainingDateManager.InsertTrainingDate(trainingDateDTO, int.Parse(userID.Value));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateTrainingResult(TrainingDateDTO trainingDateDTO)
        {
            try
            {
                var result = await _trainingDateManager.UpdateTrainingDate(trainingDateDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteTrainingDate(int id)
        {
            try
            {
                await _trainingDateManager.DeleteTrainingDate(id);
                return Ok();    
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
