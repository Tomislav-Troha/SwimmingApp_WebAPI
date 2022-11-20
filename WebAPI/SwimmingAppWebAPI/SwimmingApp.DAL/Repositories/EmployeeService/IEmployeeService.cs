using SwimmingApp.Abstract.Data;
using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.EmployeeService
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);

        Task<List<Employee>> GetEmployeeList();

        Task<Employee> GetEmployee(int id);

        Task<Employee> UpdateEmployee(Employee employee);

        Task<bool> DeleteEmployee(int key);
    }
}
