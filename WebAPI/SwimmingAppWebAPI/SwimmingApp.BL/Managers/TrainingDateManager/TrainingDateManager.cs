using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Repositories.TrainingDateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.BL.Managers.TrainingDateManager
{
    public class TrainingDateManager
    {
        private readonly ITrainingDateService _trainingDate;

        public TrainingDateManager(ITrainingDateService trainingDate)
        {
            _trainingDate = trainingDate;   
        }

        public async Task<IEnumerable<TrainingDateDTO>> GetTrainingDate(int userId)
        {
            var trainingDate = await _trainingDate.GetTrainingDate(userId);
            
            List<TrainingDateDTO> trainingDateDTOs= new List<TrainingDateDTO>();

            foreach (var traDate in trainingDate)
            {
                trainingDateDTOs.Add(new TrainingDateDTO(traDate));
            }

            return trainingDateDTOs;
        }

        public async Task<TrainingDateDTO> InsertTrainingDate(List<TrainingDateDTO> trainingDateDto, int userID)
        {
            return await _trainingDate.InsertTrainingDate(trainingDateDto, userID);
        }

        public async Task<TrainingDateDTO> UpdateTrainingDate(TrainingDateDTO trainingDateDTO)
        {
            return await _trainingDate.UpdateTrainingDate(trainingDateDTO);
        }

        public async Task DeleteTrainingDate(int id)
        {
            await _trainingDate.DeleteTrainingDate(id);
        }
    }
}
