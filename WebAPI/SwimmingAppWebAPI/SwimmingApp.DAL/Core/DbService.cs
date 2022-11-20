using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SwimmingApp.DAL.Core
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("SwimmingAplication"));
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {
            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<T>> GetAsync2<T>(string procedureName, object param = null, CommandType? commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            var result = await _db.QueryAsync<T>(procedureName, param, commandType: commandType);
            return result;
        }
    }
}
