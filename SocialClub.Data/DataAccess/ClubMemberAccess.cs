using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialClub.Data.Sql;
using System.Data.OleDb;

namespace SocialClub.Data.DataAccess
{
    public class ClubMemberAccess : ConnectionAccess, IClubMemberAccess
    {

        public DataTable GetAllClubMembers()
        {
            DataTable dataTable = new DataTable();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
 
            OleDbCommand getAllClubMembers = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            getAllClubMembers.Connection = conn;
            getAllClubMembers.CommandText = scripts.sqlGetAllClubMembers;
            oleDbDataAdapter.Fill(dataTable);

            return dataTable;

        }

        public DataRow GetClubMemberById(int id)
        {
            DataRow dataRow;
            DataTable dataTable = new DataTable();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();

            OleDbCommand getClubMemberById = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            getClubMemberById.Connection = conn;
            getClubMemberById.CommandText = scripts.sqlGetClubMembersById;

            oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Id", id);

            oleDbDataAdapter.Fill(dataTable);

            dataRow = (dataTable.Rows.Count > 0) ? dataTable.Rows[0] : null;

            return dataRow;
        }

        public DataTable SearchClubMembers(object occupation, object maritalStatus, string operand)
        {
            DataTable dataTable = new DataTable();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();

            OleDbCommand searchClubMembers = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection(ConnectionString);

            searchClubMembers.Connection = conn;

            searchClubMembers.CommandType = CommandType.Text;

            searchClubMembers.CommandText =string.Format(scripts.sqlSearchClubMembers, operand);

            oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Occupation", occupation == null ? DBNull.Value : occupation);

            oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@MaritalStatus", maritalStatus == null ? DBNull.Value : maritalStatus);

            oleDbDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public bool AddClubMember(ClubMemberModel clubMember)
        {
            DataTable dataTable = new DataTable();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();

            OleDbCommand addClubMember = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection();
            addClubMember.Connection = conn;
            addClubMember.CommandType = CommandType.Text;
            addClubMember.CommandText = scripts.sqlInsertClubMember;

            addClubMember.Parameters.AddWithValue("@Name", clubMember.Name);
            addClubMember.Parameters.AddWithValue("@DateOfBirth", clubMember.DateOfBirth.ToShortDateString());
            addClubMember.Parameters.AddWithValue("@Occupation",(int)clubMember.Occupation);
            addClubMember.Parameters.AddWithValue("@MaritalStatus",(int)clubMember.MaritalStatus);
            addClubMember.Parameters.AddWithValue("@HealthStatus",(int)clubMember.HealthStatus);
            addClubMember.Parameters.AddWithValue("@Salary", clubMember.Salary);
            addClubMember.Parameters.AddWithValue("@NumberOfChildren", clubMember.NumberOfChildren);

            addClubMember.Connection.Open();
            var rowsAffected = addClubMember.ExecuteNonQuery();
            addClubMember.Connection.Close();

            return rowsAffected > 0;
        }

        public bool UpdateClubMember(ClubMemberModel clubMember)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = scripts.sqlUpdateClubMember;
                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@Name", clubMember.Name);
                dbCommand.Parameters.AddWithValue("@DateOfBirth", clubMember.DateOfBirth.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@Occupation", (int)clubMember.Occupation);
                dbCommand.Parameters.AddWithValue("@MaritalStatus",(int)clubMember.MaritalStatus);
                dbCommand.Parameters.AddWithValue("@HealthStatus", (int)clubMember.HealthStatus);
                dbCommand.Parameters.AddWithValue("@Salary", clubMember.Salary);
                dbCommand.Parameters.AddWithValue("@NumberOfChildren", clubMember.NumberOfChildren);
                dbCommand.Parameters.AddWithValue("@Id", clubMember.Id);
                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        public bool DeleteClubMember(int id)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = scripts.sqlDeleteClubMember;
                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@Id", id);
                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }
    }
}
