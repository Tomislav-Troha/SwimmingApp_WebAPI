using SwimmingApp.Abstract.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.DataModel
{
    public class TrainingDateModel : TrainingDate
    {
         public TrainingDateModel()
        {

        }

        public TrainingDateModel(TrainingDateModel model)
        {
            UserModel = new UserModel(model.UserModel);
            TrainingModel = new TrainingModel(model.TrainingModel);
            UserRole = new UserRoleModel(model.UserRole);

            //if (model.MemberModelList != null)
            //{
            //    MemberModelList = new List<MemberModel>();
            //    foreach (var memModel in model.MemberModelList)
            //        MemberModelList.Add(new MemberModel(memModel));
            //}

            //if (model.TrainingModelList != null)
            //{
            //    TrainingModelList = new List<TrainingModel>();
            //    foreach (var traModel in model.TrainingModelList)
            //        TrainingModelList.Add(new TrainingModel(traModel));
            //}
        }

        //public List<MemberModel> MemberModelList { get; set; }
        //public List<TrainingModel> TrainingModelList { get; set; }

        public UserModel UserModel { get; set; }
        public TrainingModel TrainingModel { get; set; }

        public UserRoleModel UserRole { get; set; }
    }
}
