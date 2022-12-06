using SwimmingApp.Abstract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.AttendanceService
{
    public interface IAttendanceService
    {
        public Task<AttendanceDTO> InsertAttendance (AttendanceDTO attendanceDTO, int userID);
    }
}
