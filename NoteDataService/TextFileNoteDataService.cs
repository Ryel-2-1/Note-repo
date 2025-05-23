using NoteCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NoteDataService
{
    public class TextFileNoteDataService : INoteDataService
    {
        private string filePath = "users.txt";
        private List<UserRecord> userRecords = new List<UserRecord>();

        public TextFileNoteDataService()
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
                return;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 1)
                {
                    string name = parts[0].Trim();

                    List<string> notes = new List<string>();

                    if (parts.Length > 1 && parts[1].Length > 0)
                    {
                        string[] noteParts = parts[1].Split(',');

                        foreach (string note in noteParts)
                        {
                            notes.Add(note.Trim());
                        }
                    }

                    userRecords.Add(new UserRecord { Name = name, Notes = notes });
                }
            }
        }


        private void WriteToFile()
        {
            var lines = userRecords.Select(u =>
                $"{u.Name}|{string.Join(",", u.Notes)}").ToArray();

            File.WriteAllLines(filePath, lines);
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
            userRecords.RemoveAll(u => u.Name == user.Name);
            WriteToFile();
        }

        public void UpdateUser(UserRecord user)
        {
            int index = userRecords.FindIndex(u => u.Name == user.Name);
            if (index != -1)
            {
                userRecords[index] = user;
                WriteToFile();
            }
        }
    }
}
