using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.BL.Managers.UserLoginManager;
using SwimmingApp.BL.Managers.UserRegisterManager;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("Auth")]
    [ApiController]
    public class AuthController : Controller
    {
    
        private readonly UserRegisterManager _userRegisterManager;
        private readonly UserLoginManager _userLoginManager;
        public AuthController(UserRegisterManager userRegisterManager, UserLoginManager userLoginManager)
        {
            _userRegisterManager = userRegisterManager;
            _userLoginManager = userLoginManager;
        }


        [HttpPost("Register")]
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO login)
        {
            try
            {
                var response = await _userLoginManager.LoginUser(login);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
