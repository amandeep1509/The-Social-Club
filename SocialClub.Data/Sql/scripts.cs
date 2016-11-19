using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialClub.Data.Sql
{
    public static class scripts
    {
        

        public static readonly string sqlGetAllClubMembers = "Select" +
        " Id, Name, DateOfBirth, Occupation, MaritalStatus, " +
        "HealthStatus, Salary, NumberOfChildren" +
        " From ClubMember";

        public static readonly string sqlGetClubMembersById = "Select" +
        " Id, Name, DateOfBirth, Occupation, MaritalStatus, " +
        "HealthStatus, Salary, NumberOfChildren" +
        " From ClubMember Where Id = @Id";

        public static readonly string sqlSearchClubMembers = "Select " +
      " Id, Name, DateOfBirth, Occupation, MaritalStatus, " +
      "HealthStatus, Salary, NumberOfChildren" +
      " From ClubMember Where (@Occupation Is NULL OR @Occupation = Occupation) {0}" +
      " (@MaritalStatus Is NULL OR @MaritalStatus = MaritalStatus)";

        public static readonly string sqlInsertClubMember = "Insert Into" +
        " ClubMember(Name, DateOfBirth, Occupation," +
        " MaritalStatus, HealthStatus, Salary, NumberOfChildren)" +
        " Values(@Name, @DateOfBirth, @Occupation, " +
        "@MaritalStatus, @HealthStatus, @Salary, @NumberOfChildren)";

      

        public static readonly string sqlUpdateClubMember = "Update ClubMember " +
        " Set [Name] = @Name, [DateOfBirth] = @DateOfBirth, " +
        "[Occupation] = @Occupation, [MaritalStatus] = @MaritalStatus, " +
        " [HealthStatus] = @HealthStatus, [Salary] = @Salary, " +
        "[NumberOfChildren] = @NumberOfChildren Where ([Id] = @Id)";

        public static readonly string sqlDeleteClubMember = "Delete From ClubMember Where (Id = @Id)";
    }
}
