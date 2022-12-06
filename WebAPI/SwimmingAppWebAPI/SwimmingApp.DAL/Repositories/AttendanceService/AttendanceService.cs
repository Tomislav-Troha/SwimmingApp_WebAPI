using Dapper;
using Microsoft.AspNetCore.Routing.Matching;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IDbService _db;
        public AttendanceService(IDbService dbService)
        {
            _db = dbService;
        }

        public async Task<AttendanceDTO> InsertAttendance(AttendanceDTO attendanceDTO, int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("attDesc", attendanceDTO.AttDesc);
            param.Add("type", attendanceDTO.Type);
            param.Add("memberID", attendanceDTO.MemberModel.Id);
            param.Add("trainingID", attendanceDTO.TrainingModel.Id);
            param.Add("userID", userID);

            await _db.InsertAsync("CALL Attendance_Insert(@attDesc, @type, @memberID, @trainingID, @userID)", param);

            return attendanceDTO;
        }
    }
}
