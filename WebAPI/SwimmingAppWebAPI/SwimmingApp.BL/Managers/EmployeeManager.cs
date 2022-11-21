using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Repositories.EmployeeService;

namespace SwimmingApp.BL.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeManager(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployee(int? id)
        { 
            var employee = await _employeeService.GetEmployee(id);

            List<EmployeeDTO> testDTOs = new List<EmployeeDTO>();

            foreach (var test in employee)
            {
                testDTOs.Add(new EmployeeDTO(test));
            }
            return testDTOs;
        }

        public async Task<EmployeeDTO> InsertEmplyee(EmployeeDTO employeeDTO)
        {
            return await _employeeService.InsertEmployee(employeeDTO);
        }

        public async Task<EmployeeDTO> UpdateEmplyee(EmployeeDTO employeeDTO)
        {
            return await _employeeService.UpdateEmployee(employeeDTO);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployee(id);
        }

    }
}
