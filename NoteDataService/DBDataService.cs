using NoteCommon;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace NoteDataService
{
    public class DBDataService : INoteDataService
    {
        static string connectionString =
            "Data Source=RJ\\SQLEXPRESS01; Initial Catalog=NoteTakingApp; Integrated Security=True; TrustServerCertificate=True;";
        static SqlConnection sqlConnection;

        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void CreateUser(UserRecord user)
        {
            string insertQuery = "INSERT INTO NoteTable (UserRecord, Notes) VALUES (@UserRecord, @Notes)";
            SqlCommand command = new SqlCommand(insertQuery, sqlConnection);

            command.Parameters.Add("@UserRecord", System.Data.SqlDbType.NVarChar, 100).Value = user.Name;

            // Convert notes list to a single string; consider using a safe delimiter
            string notesText = (user.Notes != null) ? string.Join("||", user.Notes) : "";
            command.Parameters.Add("@Notes", System.Data.SqlDbType.NVarChar, -1).Value = notesText;

            try
            {
                sqlConnection.Open();
                Console.WriteLine($"Executing query to insert UserRecord='{user.Name}', Notes='{notesText}'");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating user: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<UserRecord> GetUsers()
        {
            string selectQuery = "SELECT UserRecord, Notes FROM NoteTable";
            SqlCommand command = new SqlCommand(selectQuery, sqlConnection);

            var users = new List<UserRecord>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["UserRecord"].ToString();
                    string notesText = reader["Notes"].ToString();

                    List<string> notes = string.IsNullOrEmpty(notesText)
                        ? new List<string>()
                        : new List<string>(notesText.Split(new string[] { "||" }, StringSplitOptions.None));

                    users.Add(new UserRecord { Name = name, Notes = notes });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading users: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return users;
        }

        public void RemoveUser(UserRecord user)
        {
            string deleteQuery = "DELETE FROM NoteTable WHERE UserRecord = @UserRecord";
            SqlCommand command = new SqlCommand(deleteQuery, sqlConnection);
            command.Parameters.AddWithValue("@UserRecord", user.Name);

            try
            {
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing user: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateUser(UserRecord user)
        {
            string updateQuery = "UPDATE NoteTable SET Notes = @Notes WHERE UserRecord = @UserRecord";
            SqlCommand command = new SqlCommand(updateQuery, sqlConnection);

            command.Parameters.AddWithValue("@UserRecord", user.Name);
            string notesText = (user.Notes != null) ? string.Join("||", user.Notes) : "";
            command.Parameters.AddWithValue("@Notes", notesText);

            try
            {
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}

