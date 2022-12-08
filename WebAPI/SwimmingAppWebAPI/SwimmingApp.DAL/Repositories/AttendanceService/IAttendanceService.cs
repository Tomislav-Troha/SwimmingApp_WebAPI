using SwimmingApp.Abstract.DataModel;
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
        Task<AttendanceDTO> InsertAttendance (AttendanceDTO attendanceDTO, int userID);

        Task<IEnumerable<AttendanceModel>> GetAttendanceByUserID(int userID);

        Task DeleteAttendance(int id);

    }
}
