using Dapper;
using Microsoft.IdentityModel.Tokens;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.DAL.Contex;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SwimmingApp.DAL.Repositories.UserService
{
    public class UserService : IUserService
    {
        private readonly IDbService _db;
        private readonly DapperContext _contex;
        public UserService(IDbService dbService, DapperContext context)
        {
            _db = dbService;
            _contex = context;
        }

        public Task<UserModel> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetByID(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            var query = "SELECT * FROM User_Select_ByID(@id)";

            using var connection = _contex.CreateConnection();

            IEnumerable<UserModel> users = await connection.QueryAsync<UserModel, UserRoleModel, UserModel>(query,
                (user, userRole) =>
                {
                    user.UserRoleModel = userRole;
                    return user;
                }, param, splitOn: "roleid");

            return users.FirstOrDefault();
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("email", email);

            var query = "SELECT * FROM User_Select_byEmail(@email)";

            using var connection = _contex.CreateConnection();

            IEnumerable<UserModel> users = await connection.QueryAsync<UserModel, UserRoleModel, UserModel>(query,
               (user, userRole) =>
               {
                   user.UserRoleModel = userRole;
                   return user;
               }, param, splitOn: "roleid");

            return users.FirstOrDefault();
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("username", username);

            return await _db.FindAsync<UserModel>("SELECT * FROM User_Select_ByUsername(@username)", param);
        }

        public async Task<UserModel> GetUserLoginData(string email)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("email", email);

            return await _db.FindAsync<UserModel>("SELECT * FROM User_Select_LoginData(@email)", param);
        }

        public async Task<UserModel> InsertUser(UserModel userModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("name", userModel.Name);
            param.Add("surname", userModel.Surname);
            param.Add("email", userModel.Email);
            param.Add("username", userModel.Username);
            param.Add("password", userModel.Password);
            param.Add("salt", userModel.Salt);
            param.Add("adress", userModel.Adress);
            param.Add("userRoleID", userModel.UserRoleID);

            await _db.InsertAsync("CALL User_Insert(@name, @surname, @email, @username, @password, @adress, @userRoleID, @salt)", param);

            return userModel;
        }

        public Task<UserModel> UpdateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
