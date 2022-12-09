using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.UserService
{
    public interface IUserService
    {
        Task<UserModel> GetByID(int id);
        Task<UserModel> InsertUser(UserModel userModel);
        Task<UserModel> GetUserLoginData(string username);
        Task<UserModel> GetUserByEmail(string email);
        Task<UserModel> GetUserByUsername(string username);
        Task<UserModel> UpdateUser(UserModel userModel);
        Task<UserModel> DeleteUser(int id);
        Task<UserRoleModel> SetUserRole(UserRoleModel model, int id);
        Task<IEnumerable<UserModel>> GetUsersRoleNull();
    }
}
