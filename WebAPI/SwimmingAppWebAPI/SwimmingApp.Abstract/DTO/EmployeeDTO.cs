using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.DTO
{
    public class EmployeeDTO : EmployeeModel
    {
        public EmployeeDTO(EmployeeModel employeeModel)
        {
            Id = employeeModel.Id;
            Password = employeeModel.Password;
            Name = employeeModel.Name;
            Adress = employeeModel.Adress;
            Mobile = employeeModel.Mobile;
            Email = employeeModel.Email;
        }

        public EmployeeDTO() { }

    }
}
