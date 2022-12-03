using Microsoft.AspNetCore.Mvc;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.BL.Managers.MemberManager;

namespace SwimmingAppWebAPI.Controllers
{
    [Route("member")]
    [ApiController]
    public class MemberController : Controller
    {
        private readonly MemberManager _memberManager;

        public MemberController(MemberManager memberManager)
        {
            _memberManager = memberManager; 
        }

        [HttpPost]
        public async Task<IActionResult> PostMember(MemberDTO memberDTO)
        {
            try
            {
                await _memberManager.InsertMember(memberDTO);
                return Ok(memberDTO);
            }
            catch (Exception e)
            {
                return BadRequest($"Could not insert {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMember(int? id = null)
        {
            try
            {
                var result = await _memberManager.GetMember(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember(MemberDTO memberDTO)
        {
            try
            {
                var result = await _memberManager.UpdateMember(memberDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                await _memberManager.DeleteMember(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
