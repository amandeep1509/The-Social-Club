using SocialClub.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialClub.Data.Sql;
using System.Data;

namespace SocialClub.Data.BusinessService
{
    class ClubMemberService : IClubMemberService
    {

        private IClubMemberAccess memberAccess;

        public ClubMemberService()
        {
           
            this.memberAccess = new ClubMemberAccess();
        }

        public DataTable GetAllClubMembers()
        {
            return memberAccess.GetAllClubMembers();
        }

        public DataRow GetClubMemberById(int id)
        {
            return memberAccess.GetClubMemberById(id);
        }

        public DataTable SearchClubMembers(object occupation, object maritalStatus, string operand)
        {
            return memberAccess.SearchClubMembers(occupation, maritalStatus, operand);
        }

        public bool AddClubMember(ClubMemberModel clubMember)
        {
            return memberAccess.AddClubMember(clubMember);
        }

        public bool UpdateClubMember(ClubMemberModel clubMember)
        {
            return memberAccess.UpdateClubMember(clubMember);
        }

        public bool DeleteClubMember(int id)
        {
            return memberAccess.DeleteClubMember(id);
        }
    }
}
