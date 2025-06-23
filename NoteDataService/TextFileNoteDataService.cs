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
        private List<UserRecord> users = new List<UserRecord>();

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

                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(parts[i]))
                        {
                            notes.Add(parts[i].Trim());
                        }
                    }
                    users.Add(new UserRecord { Name = name, Notes = notes });
                }
            }
        }


        private void WriteToFile()
        {
            var lines = new string[users.Count];

            for (int i = 0; i < users.Count; i++)
            {
                lines[i] = users[i].Name + "|" + string.Join("|", users[i].Notes);

            }

            File.WriteAllLines(filePath, lines);
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
            foreach (var existingUser in users)
            {
                if (existingUser.Name == user.Name)
                {
                    existingUser.Notes.AddRange(user.Notes);
                    WriteToFile();
                    return true;
                }
            }
            return false;
        }

        public bool UpdateNotes(string user, int index, string note)
        {
            foreach (var existingUser in users)
            {
                if (existingUser.Name == user && index >= 0 && index < existingUser.Notes.Count)
                {
                    existingUser.Notes[index] = note;
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
                    int noteIndex = Convert.ToInt32(index);
                    noteIndex--;
                    if (noteIndex >= 0 && noteIndex < existingUser.Notes.Count)
                    {
                        existingUser.Notes.RemoveAt(noteIndex);
                        WriteToFile();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}