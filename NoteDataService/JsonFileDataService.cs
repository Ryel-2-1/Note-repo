using NoteCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NoteDataService
{
    public class JsonFileNoteDataService : INoteDataService
    {
        static List<UserRecord> users = new List<UserRecord>();
        static string jsonFilePath = "users.json";

        public JsonFileNoteDataService()
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            string jsonText = File.ReadAllText(jsonFilePath);

            users = JsonSerializer.Deserialize<List<UserRecord>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }
       

        private void WriteToFile()
        {
            string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonString);
        }

        public void CreateUser(UserRecord user)
        {
            users.Add(user);
            WriteToFile();
        }

        public List<UserRecord> GetUsers()
        {
            return users;
        }
        public bool AddNote(UserRecord user)
        {
            foreach (var userRecord in users)
            {
                if (userRecord.Name == user.Name)
                {
                    userRecord.Notes.AddRange(user.Notes);
                    WriteToFile();
                    return true;
                }
            }
            return false;
        }

        public bool UpdateNotes(string user, int index, string note)
        {
            foreach (var userRecord in users)
            {
                if (userRecord.Name == user)
                {
                    if (index < 0 || index >= userRecord.Notes.Count)
                        return false;
                    userRecord.Notes[index] = note;
                    WriteToFile();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteNote(UserRecord user, string index)
        {
            foreach (var existingUser in users)
            {
                if (existingUser.Name == user.Name)
                {
                    int ind = Convert.ToInt32(index);
                    if (ind >= 0 && ind < existingUser.Notes.Count)
                    {
                        existingUser.Notes.RemoveAt(ind);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}