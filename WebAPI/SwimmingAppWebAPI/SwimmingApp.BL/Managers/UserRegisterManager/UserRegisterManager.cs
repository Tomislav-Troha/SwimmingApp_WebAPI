using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Repositories.UserRegisterService;
using SwimmingApp.DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.BL.Managers.UserRegisterManager
{
    public class UserRegisterManager
    {
        private readonly UserRegisterService _userRegisterService;
        public UserRegisterManager(UserRegisterService userRegisterService)
        {
            _userRegisterService = userRegisterService;
        }

        public async Task<UserRegisterResponse> UserRegister(UserRegisterDTO request, int adminID)
        {
            return await _userRegisterService.UserRegister(request, adminID);   
        }
    }
}
