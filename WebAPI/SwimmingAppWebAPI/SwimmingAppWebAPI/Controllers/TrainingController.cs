using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.BL.Managers.TrainingManager;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("Training")]
    [ApiController]
    public class TrainingController : Controller
    {
        private readonly TrainingManager _trainingManager;

        public TrainingController(TrainingManager trainingManager)
        {
            _trainingManager = trainingManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetTraining(int? id = null)
        {
            try
            {
                var response = await _trainingManager.GetTraining(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertTraining(TrainingDTO model)
        {
            try
            {
                var result = await _trainingManager.InsertTraining(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTraining(TrainingDTO model)
        {
            try
            {
                var result = await _trainingManager.UpdateTraining(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            try
            {
                await _trainingManager.DeleteTraining(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
