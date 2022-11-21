using SwimmingApp.Abstract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.BL.Managers
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployee(int? id);
        Task<EmployeeDTO> InsertEmplyee(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> UpdateEmplyee(EmployeeDTO employeeDTO);
        Task DeleteEmployee(int id);
    }
}
