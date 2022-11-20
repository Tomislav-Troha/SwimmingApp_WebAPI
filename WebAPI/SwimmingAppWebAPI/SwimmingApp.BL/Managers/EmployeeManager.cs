using SwimmingApp.Abstract.DataModel;
using SwimmingApp.DAL.Repositories.EmployeeService;

namespace SwimmingApp.BL.Managers
{
    public class EmployeeManager
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeManager(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<bool> CreateEmployee(EmployeeModel employeeModel)
        {
            var employee = await _employeeService.CreateEmployee(employeeModel);

            //List<TestDTO> testDTOs = new List<TestDTO>();

            //foreach (var test in testovi)
            //{
            //    testDTOs.Add(new TestDTO(test));
            //}
            return employee;
        }
    }
}
