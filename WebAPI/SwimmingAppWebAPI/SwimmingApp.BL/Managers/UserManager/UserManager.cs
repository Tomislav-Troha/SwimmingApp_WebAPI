using SwimmingApp.Abstract.DataModel;
using SwimmingApp.DAL.Repositories.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.BL.Managers.UserManager
{
    public class UserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService; 
        }

        public async Task<UserModel> GetUserByID(int id)
        {
            return await _userService.GetByID(id);
        }
    }
}
