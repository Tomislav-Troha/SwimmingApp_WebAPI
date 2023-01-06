using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.DTO
{
    public class TrainingDateDTO : TrainingDateModel
    {
        public TrainingDateDTO(TrainingDateModel model) 
        {
            ID_TrainingDate = model.ID_TrainingDate;
            Dates = model.Dates;
            Time = model.Time;
            MemberModel = model.MemberModel != null ? new MemberDTO(model.MemberModel) : null;
            TrainingModel = model.TrainingModel != null ? new TrainingDTO(model.TrainingModel) : null;
        }

        public TrainingDateDTO()
        {

        }
    }
}
