using SwimmingApp.Abstract.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.DataModel
{
    public class AttendanceModel : Attendance
    {
        public AttendanceModel()
        {

        }

        public AttendanceModel(AttendanceModel model)
        {
            MemberModel = new MemberModel(model.MemberModel);
            TrainingModel = new TrainingModel(model.TrainingModel);
        }

        public MemberModel MemberModel { get; set; }
        public TrainingModel TrainingModel { get; set; }
    }
}
