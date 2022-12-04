using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
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


    }
}
