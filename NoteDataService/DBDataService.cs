using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using NoteCommon;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace NoteDataService
{
    public class DBDataService : INoteDataService
    {
        static string connectionString =
            "Data Source=RJ\\SQLEXPRESS01; Initial Catalog=NoteTakingApp; Integrated Security=True; TrustServerCertificate=True;";
        static SqlConnection sqlConnection;
        List<UserRecord> userRecords = new List<UserRecord>();
        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
            GetDataFromDB();
        }
        public void GetDataFromDB()
        {
            userRecords.Clear();
            sqlConnection.Open();
            string selectQuery = "SELECT * FROM NoteTable";
            SqlCommand command = new SqlCommand(selectQuery, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Name = reader["Name"].ToString();
                string Notes = reader["Notes"].ToString();
                if (!string.IsNullOrEmpty(Notes))
                {
                    userRecords.Add(new UserRecord
                    {
                        Name = Name,
                        Notes = Notes.Split('|').ToList()
                    });
                }
            }
            reader.Close();
            sqlConnection.Close();
        }
        public List<UserRecord> GetUsers()
        {
            return userRecords;
        }
        public void CreateUser(UserRecord user)
        {
            userRecords.Add(user);
            sqlConnection.Open();
            string insertQuery = "INSERT INTO NoteTable (Name, Notes) VALUES (@Name, @Notes)";
            SqlCommand command = new SqlCommand(insertQuery, sqlConnection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Notes", string.Join("|", user.Notes));
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public bool AddNote(UserRecord user)
        {
            foreach (var existingUser in userRecords)
            {
                if (existingUser.Name == user.Name)
                {
                    existingUser.Notes.Add(user.Notes.Last());
                    UpdateUserInDB(existingUser);
                    return true;
                }
            }
            return false;
        }
        private void UpdateUserInDB(UserRecord user)
        {
            sqlConnection.Open();
            string updateQuery = "UPDATE NoteTable SET Notes = @Notes WHERE Name = @Name";
            SqlCommand command = new SqlCommand(updateQuery, sqlConnection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Notes", string.Join("|", user.Notes));
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public bool UpdateNotes(string user, int index, string note)
        {
            foreach (var existingUser in userRecords)
            {
                if (index >= 0 && index < existingUser.Notes.Count)
                {
                    existingUser.Notes[index] = note;
                    UpdateUserInDB(existingUser);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteNote(UserRecord user, string index)
        {
            foreach (var existingUser in userRecords)
            {
                if (existingUser.Name == user.Name)
                {
                    int ind = Convert.ToInt32(index);
                    ind--;
                    if (ind >= 0 && ind < existingUser.Notes.Count)
                    {
                        existingUser.Notes.RemoveAt(ind);
                        UpdateUserInDB(existingUser);
                        return true;
                    }
                    break;
                }
            }
            return false;
        }
    }
}
