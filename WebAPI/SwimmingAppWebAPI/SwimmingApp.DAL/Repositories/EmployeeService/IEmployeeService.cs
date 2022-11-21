using SwimmingApp.Abstract.Data;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.EmployeeService
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> InsertEmployee(EmployeeDTO employeeDTO);

        Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO);

        Task<IEnumerable<EmployeeModel>> GetEmployee(int? id);

        Task DeleteEmployee(int id);

       
    }
}
