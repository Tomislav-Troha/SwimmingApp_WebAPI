using SwimmingApp.Abstract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.BL.Managers.MemberManager
{
    public interface IMemberManager
    {
        Task<IEnumerable<MemberDTO>> GetMember(int? id);
        Task<MemberDTO> InsertMember(MemberDTO memberDTO);
        Task<MemberDTO> UpdateMember(MemberDTO memberDTO);
        Task DeleteMember(int id);
    }
}
