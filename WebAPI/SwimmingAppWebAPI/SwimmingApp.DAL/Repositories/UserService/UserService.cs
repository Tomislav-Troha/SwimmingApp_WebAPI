using Dapper;
using Microsoft.IdentityModel.Tokens;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.UserService
{
    public class UserService : IUserService
    {
        private readonly IDbService _db;
        public UserService(IDbService dbService)
        {
            _db = dbService;
        }

        public Task<UserModel> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetByID(int id)
        {
            var query = "SELECT * FROM \"User\" WHER id = @id";

            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            return await _db.FindAsync<UserModel>(query, param);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("email", email);

            return await _db.FindAsync<UserModel>("SELECT * FROM User_Select_byEmail(@email)", param);
        }

        public Task<UserModel> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserLoginData(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> InsertUser(UserModel userModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("name", userModel.Name);
            param.Add("surname", userModel.Surname);
            param.Add("email", userModel.Email);
            param.Add("username", userModel.Username);
            param.Add("password", userModel.Password);
            param.Add("adress", userModel.Adress);

            await _db.InsertAsync("CALL User_Insert(@name, @surname, @email, @username, @password, @adress)", param);

            return userModel;
        }

        public Task<UserModel> UpdateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
