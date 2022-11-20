using SwimmingApp.Abstract.Data;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<bool> CreateEmployee(Employee employee)
        {
            var result =
                await _dbService.EditData(
                    "CALL Employee_Insert (@password, @name, @adress, @mobile, @email)", employee);

            return true;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _dbService.GetAll<Employee>("select * from Employee_Select()", new { });

            return employeeList;
        }
        public async Task<Employee> GetEmployee(int id)
        {
            var result =
                 await _dbService.GetAsync<Employee>(
                     "SELECT * FROM Employee_SelectOne(@id)", new { id });
            return result;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updateEmployee = await _dbService.EditData(
                "CALL Employee_Update(@id, @password, @name, @adress, @mobile, @email)", employee);
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result =
                await _dbService.EditData(
                    "CALL Employee_Delete(@id)", new { id });

            return true;
        }


    }
}
