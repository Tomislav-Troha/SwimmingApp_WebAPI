using SwimmingApp.Abstract.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.DTO
{
    public class MemberDTO : MemberModel
    {
        public MemberDTO(MemberModel memberModel)
        {
            Id = memberModel.Id;
            Name = memberModel.Name;
            Surname= memberModel.Surname;
            MemberFrom = memberModel.MemberFrom;
        }

        public MemberDTO()
        {

        }
    }
}

