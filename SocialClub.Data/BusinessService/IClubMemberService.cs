﻿using System.Data;

namespace SocialClub.Data.BusinessService
{
    public interface IClubMemberService
    {
        DataTable GetAllClubMembers();

        DataRow GetClubMemberById(int id);

        DataTable SearchClubMembers(object occupation, object maritalStatus, string operand);

        bool AddClubMember(ClubMemberModel clubMember);

        bool UpdateClubMember(ClubMemberModel clubMember);

        bool DeleteClubMember(int id);
    }
}