using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.DTO
{
    public class UserRoleDTO : UserRoleModel
    {
        public UserRoleDTO()
        {

        }
        public UserRoleDTO(UserRoleModel userRoleModel)
        {
            Id= userRoleModel.Id;
            RoleName= userRoleModel.RoleName;
            RoleDesc= userRoleModel.RoleDesc;
        }


    }
}
