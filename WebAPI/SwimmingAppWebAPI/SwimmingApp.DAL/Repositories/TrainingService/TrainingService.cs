using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.TrainingService
{
    public class TrainingService : ITrainingService
    {
        public Task DeleteTraining(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrainingModel>> GetTraining(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDTO> InsertTraining(TrainingDTO trainingDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingDTO> UpdateTraining(TrainingDTO trainingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
