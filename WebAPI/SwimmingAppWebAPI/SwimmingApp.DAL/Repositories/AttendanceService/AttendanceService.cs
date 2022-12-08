using Dapper;
using Microsoft.AspNetCore.Routing.Matching;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Contex;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IDbService _db;
        private readonly DapperContext _contex;
        public AttendanceService(IDbService dbService, DapperContext context)
        {
            _db = dbService;
            _contex = context;
        }

        public async Task DeleteAttendance(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            await _db.DeleteAsync("CALL Attendance_Delete(@id)", param);
        }

        public async Task<IEnumerable<AttendanceModel>> GetAttendanceByUserID(int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("userId", userID);

            var query = "SELECT * FROM Attendance_Select_ByUser(@userId)";
            using var connection = _contex.CreateConnection();

            IEnumerable<AttendanceModel> attendances = await connection.QueryAsync<AttendanceModel, MemberModel, TrainingModel, AttendanceModel>(query,
                (attendance, member, training) =>
                {
                    attendance.MemberModel = member;
                    attendance.TrainingModel = training;
                    return attendance;
                }, param, splitOn: "ID_member, ID_training");

            return attendances;
        }

        public async Task<AttendanceDTO> InsertAttendance(AttendanceDTO attendanceDTO, int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("attDesc", attendanceDTO.AttDesc);
            param.Add("type", attendanceDTO.Type);
            param.Add("memberID", attendanceDTO.MemberModel.ID_member);
            param.Add("trainingID", attendanceDTO.TrainingModel.ID_training);
            param.Add("userID", userID);

            await _db.InsertAsync("CALL Attendance_Insert(@attDesc, @type, @memberID, @trainingID, @userID)", param);

            return attendanceDTO;
        }
    }
}
