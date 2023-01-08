using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.BL.Managers.UserManager;
using System.ComponentModel.DataAnnotations;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("User controller")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager _userManager;
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            try
            {
                var result = await _userManager.GetUserByID(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("SetUserRole")]
        public async Task<IActionResult> SetUserRole(UserRoleModel model, int id)
        {
            try
            {
                var result = await _userManager.UserSetRole(model, id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("UserRoleIsNull")]
        public async Task<IActionResult> GetUserRoleNull()
        {
            try
            {
                var result = await _userManager.GetUserRoleNull();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
