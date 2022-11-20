using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Core
{
    public interface IDbService
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GetAll<T>(string command, object parms);
        Task<int> EditData(string command, object parms);

        Task<IEnumerable<T>> GetAsync2<T>(string procedureName, object param = null, CommandType? commandType = CommandType.StoredProcedure, int? commandTimeout = null);

    }
}
