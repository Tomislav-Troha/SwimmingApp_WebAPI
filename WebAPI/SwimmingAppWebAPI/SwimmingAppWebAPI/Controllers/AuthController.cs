using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.BL.Managers.UserRegisterManager;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("Auth")]
    [ApiController]
    public class AuthController : Controller
    {
    
        private readonly UserRegisterManager _userRegisterManager;
        public AuthController(UserRegisterManager userRegisterManager)
        {
            _userRegisterManager = userRegisterManager;
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                //var adminId = HttpContext?.User.Claims.Where(x => x.Type == "UserId").Single();
                var response = await _userRegisterManager.UserRegister(userRegisterDTO, 1);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           
        }


    }
}
