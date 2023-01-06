using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Repositories.MemberService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.BL.Managers.MemberManager
{
    public class MemberManager
    {
        private readonly IMemberService _memberService;
        public MemberManager(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task DeleteMember(int id)
        {
           await _memberService.DeleteMember(id);
        }

        public async Task<IEnumerable<MemberDTO>> GetMember(int? id)
        {
            var members = await _memberService.GetMember(id);

            List<MemberDTO> memberDTOs= new List<MemberDTO>();

            foreach (var member in members) 
            {
                memberDTOs.Add(new MemberDTO(member));
            }

            return memberDTOs;
        }

        public async Task<MemberDTO> InsertMember(MemberDTO memberDTO)
        {
            return await _memberService.InsertMember(memberDTO);
        }

        public async Task<MemberDTO> UpdateMember(MemberDTO memberDTO)
        {
            return await _memberService.UpdateMember(memberDTO);
        }
    }
}
