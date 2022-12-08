using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.DTO
{
    public class AttendanceDTO : AttendanceModel
    {
        public AttendanceDTO(AttendanceModel model)
        {
            ID_attendance = model.ID_attendance;
            AttDesc = model.AttDesc;
            Type = model.Type;
            MemberModel = model.MemberModel != null ? new MemberDTO(model.MemberModel) : null;
            TrainingModel = model.TrainingModel != null ? new TrainingDTO(model.TrainingModel) : null;
        }

        public AttendanceDTO()
        {

        }
    }
}
