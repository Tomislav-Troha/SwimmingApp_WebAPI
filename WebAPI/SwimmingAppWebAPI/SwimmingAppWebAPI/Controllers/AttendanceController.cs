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


        [HttpPost]
        public async Task<IActionResult> InsertAttendance (AttendanceDTO attendanceDTO)
        {
            try
            {
                int userID = 13;
                var result = await _attendanceManager.InsertAttendance(attendanceDTO, userID);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
    }
}
