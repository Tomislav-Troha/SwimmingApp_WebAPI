using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Repositories.MemberService
{
    public interface IMemberService
    {
        Task<MemberDTO> InsertMember(MemberDTO memberDTO);

        Task<MemberDTO> UpdateMember(MemberDTO memberDTO);

        Task<IEnumerable<MemberModel>> GetMember(int? id);

        Task DeleteMember(int id);
    }
}
