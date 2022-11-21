using Dapper;
using SwimmingApp.Abstract.Data;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbService _dbService;

        public EmployeeService(IDbService dbService)
        {
            _dbService = dbService;
        }

       public async Task<IEnumerable<EmployeeModel>> GetEmployee(int? id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            return  await _dbService.GetAsync<EmployeeModel>(
                     "SELECT * FROM Employee_SelectOne(@id)", param);
            
        }

        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", employeeDTO.Id);
            param.Add("password", employeeDTO.Password);
            param.Add("name", employeeDTO.Name);
            param.Add("adress", employeeDTO.Adress);
            param.Add("mobile", employeeDTO.Mobile);
            param.Add("email", employeeDTO.Email);

            await _dbService.UpdateAsync(
                "CALL Employee_Update(@id, @password, @name, @adress, @mobile, @email)", param);

            return employeeDTO;
        }

        public async Task<EmployeeDTO> InsertEmployee(EmployeeDTO employeeDTO)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("password", employeeDTO.Password);
            param.Add("name", employeeDTO.Name);
            param.Add("adress", employeeDTO.Adress);
            param.Add("mobile", employeeDTO.Mobile);
            param.Add("email", employeeDTO.Email);

            await _dbService.InsertAsync("CALL Employee_Insert(@password, @name, @adress, @mobile, @email)", param);

            return employeeDTO;
        }

        public async Task DeleteEmployee(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);
            
            await _dbService.DeleteAsync("CALL Employee_Delete(@id)", param);
        }
    }
}
