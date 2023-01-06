using Dapper;
using SwimmingApp.Abstract.Data;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Contex;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.TrainingDateService
{
    public class TrainingDateService : ITrainingDateService
    {

        private readonly IDbService _db;
        private readonly DapperContext _contex;

        public TrainingDateService(IDbService dbService, DapperContext context)
        {
            _db = dbService;
            _contex = context;
        }

        public async Task DeleteTrainingDate(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            await _db.DeleteAsync("CALL TrainingDate_Delete(@id)", param);
        }

        public async Task<IEnumerable<TrainingDateDTO>> GetTrainingDate(int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("userId", userID);

            var query = "SELECT * FROM TrainingDate_Select(@userId)";
            using var connection = _contex.CreateConnection();

            IEnumerable<TrainingDateDTO> trainingDates = await connection.QueryAsync<TrainingDateDTO, MemberModel, TrainingModel, TrainingDateDTO>(query,
                (trainingDate, member, training) =>
                {
                    trainingDate.MemberModel = member;
                    trainingDate.TrainingModel = training;
                    return trainingDate;
                }, param, splitOn: "ID_member, ID_training");

            return trainingDates;
        }

        public async Task<TrainingDateDTO> InsertTrainingDate(TrainingDateDTO trainingDateDTO, int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("dates", trainingDateDTO.Dates);
            param.Add("time", trainingDateDTO.Time);
            param.Add("memberID", trainingDateDTO.MemberModel.ID_member);
            param.Add("trainingID", trainingDateDTO.TrainingModel.ID_training);
            param.Add("UserID", userID);

            await _db.InsertAsync("CALL TrainingDate_Insert(@dates, @time, @memberID, @trainingID, @userID)", param);

            return trainingDateDTO;
        }

        public async Task<TrainingDateDTO> UpdateTrainingDate(TrainingDateDTO trainingDateDTO)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", trainingDateDTO.ID_TrainingDate);
            param.Add("dates", trainingDateDTO.Dates);
            param.Add("time", trainingDateDTO.Time);
            param.Add("memberID", trainingDateDTO.MemberModel.ID_member);
            param.Add("trainingID", trainingDateDTO.TrainingModel.ID_training);

            await _db.UpdateAsync("CALL TrainingDate_Update(@id, @dates, @time, @memberID, @trainingID)", param);

            return trainingDateDTO;
        }
    }
}
