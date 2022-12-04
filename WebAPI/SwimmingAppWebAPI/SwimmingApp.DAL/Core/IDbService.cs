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
        Task<IEnumerable<T>> GetAsync<T>(string command, object parms);
        Task<T> FindAsync<T>(string command, object parms);
        Task<int> UpdateAsync(string command, object parms);
        Task<DbInsertResult> InsertAsync(string command, object parms);
        Task<int> DeleteAsync(string command, object parms);
    }
}
