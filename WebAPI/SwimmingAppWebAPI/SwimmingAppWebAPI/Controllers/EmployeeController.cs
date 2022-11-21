using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.Data;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.BL.Managers;
using SwimmingApp.DAL.Repositories.EmployeeService;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeManager _employeeManager;
        public EmployeeController(EmployeeManager employeeManager) 
        {
            _employeeManager = employeeManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployee(int? id = null)
        {
            try
            {
                var result = await _employeeManager.GetEmployee(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var result = await _employeeManager.InsertEmplyee(employeeDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeManager.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not delete {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var result = await _employeeManager.UpdateEmplyee(employeeDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not update {ex.Message}");
            }
        }
    }
}
