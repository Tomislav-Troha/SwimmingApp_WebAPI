using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.Data;
using SwimmingApp.DAL.Repositories.EmployeeService;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService; 
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var result = await _employeeService.GetEmployeeList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeService.GetEmployee(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {
            try
            {
                var result = await _employeeService.CreateEmployee(employee);
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
                var result = await _employeeService.DeleteEmployee(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not delete {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody]Employee employee)
        {
            try
            {
                var result = await _employeeService.UpdateEmployee(employee);
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not update {ex.Message}");
            }
        }
    }
}
