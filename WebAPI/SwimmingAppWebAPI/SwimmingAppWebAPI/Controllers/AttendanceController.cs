using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.BL.Managers.AttendanceManager;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("Attendance")]
    [ApiController]
    public class AttendanceController : Controller
    {
        private readonly AttendanceManager _attendanceManager;
        public AttendanceController(AttendanceManager attendanceManager)
        {
            _attendanceManager = attendanceManager;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertAttendance (AttendanceDTO attendanceDTO)
        {
            try
            {
                var userId = HttpContext?.User.Claims.Where(x => x.Type == "UserID").Single();
                //var userRoleId = HttpContext?.User.Claims.Where(x => x.Type == "UserRoleId").Single();
                var result = await _attendanceManager.InsertAttendance(attendanceDTO, int.Parse(userId.Value));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAttendanceByUser()
        {
            try
            {
                var userId = HttpContext?.User.Claims.Where(x => x.Type == "UserID").Single();
                var response = await _attendanceManager.GetAttendanceByUser(int.Parse(userId.Value));
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            try
            {
                await _attendanceManager.DeleteAttendance(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
    }
}
