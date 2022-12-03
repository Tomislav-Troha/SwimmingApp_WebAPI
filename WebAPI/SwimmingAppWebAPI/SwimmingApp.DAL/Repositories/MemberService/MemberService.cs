using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SwimmingApp.Abstract.DataModel;
using SwimmingApp.Abstract.DTO;
using SwimmingApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwimmingApp.DAL.Repositories.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IDbService _db;
        public MemberService(IDbService dbService)
        {
            _db = dbService;
        }

        public async Task DeleteMember(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            await _db.DeleteAsync("CALL Member_Delete(@id)", param);
        }

        public async Task<IEnumerable<MemberModel>> GetMember(int? id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", id);

            return await _db.GetAsync<MemberModel>(
                    "SELECT * FROM Member_Select(@id)", param);
        }

        public async Task<MemberDTO> InsertMember(MemberDTO memberDTO)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("name", memberDTO.Name);
            param.Add("surname", memberDTO.Surname);
            param.Add("member_from", memberDTO.MemberFrom);

            await _db.InsertAsync("CALL Member_Insert(@name, @surname, @member_from)", param);

            return memberDTO;
        }

        public async Task<MemberDTO> UpdateMember(MemberDTO memberDTO)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", memberDTO.Id);
            param.Add("name", memberDTO.Name);
            param.Add("surname", memberDTO.Surname);
            param.Add("member_from", memberDTO.MemberFrom);

            await _db.UpdateAsync("CALL Member_Update(@id, @name, @surname, @member_from)", param);

            return memberDTO;
        }
    }
}
