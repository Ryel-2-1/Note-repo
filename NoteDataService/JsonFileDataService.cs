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
         static List<UserRecord> userRecords = new List<UserRecord>();
         static string jsonFilePath = "users.json";

        public JsonFileNoteDataService()
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(jsonFilePath))
                return;

            string jsonText = File.ReadAllText(jsonFilePath);

            userRecords = JsonSerializer.Deserialize<List<UserRecord>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (userRecords == null)
                userRecords = new List<UserRecord>();
        }

        private void WriteToFile()
        {
            string jsonString = JsonSerializer.Serialize(userRecords, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonString);
        }

        private int FindUserIndex(string name)
        {
            for (int i = 0; i < userRecords.Count; i++)
            {
                if (userRecords[i].Name.Trim().ToLower() == name.Trim().ToLower())
                    return i;
            }
            return -1;
        }

        public void CreateUser(UserRecord user)
        {
            userRecords.Add(user);
            WriteToFile();
        }

        public List<UserRecord> GetUsers()
        {
            return userRecords;
        }

        public void RemoveUser(UserRecord user)
        {
            int index = FindUserIndex(user.Name);
            if (index != -1)
            {
                userRecords.RemoveAt(index);
                WriteToFile();
            }
        }

        public void UpdateUser(UserRecord user)
        {
            int index = FindUserIndex(user.Name);
            if (index != -1)
            {
                userRecords[index].Name = user.Name;
                userRecords[index].Notes = user.Notes;
                WriteToFile();
            }
        }
    }
}
