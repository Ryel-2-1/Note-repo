using NoteCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteDataService
{
    public class InMemoryNoteDataService : INoteDataService
    {
        List<UserRecord> users = new List<UserRecord>();

        public InMemoryNoteDataService()
        {
            CreateDummyUsers();
        }

        private void CreateDummyUsers()
        {
            users.Add(new UserRecord { Name = "Jhomar", Notes = new List<string> { "buy groceries", "play games" } });
            users.Add(new UserRecord { Name = "abdul", Notes = new List<string> { "wash the dishes", "pending backlogs" } });
            users.Add(new UserRecord { Name = "Ryel", Notes = new List<string> { "scrims", "homework" } });
            users.Add(new UserRecord { Name = "nyerk", Notes = new List<string> { "aga", "merk" } });
        }

        public void CreateUser(UserRecord user)
        {
            users.Add(user);
        }

        public List<UserRecord> GetUsers()
        {
            return users;
        }
        public bool AddNote(UserRecord user)
        {
            foreach (var existingUser in users)
            {
                if (string.Equals(existingUser.Name, user.Name, StringComparison.OrdinalIgnoreCase))
                {
                    existingUser.Notes.AddRange(user.Notes);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateNotes(string user, int index, string note)
        {
            foreach (var existingUser in users)
            {
                if (string.Equals(existingUser.Name, user, StringComparison.OrdinalIgnoreCase) && index >= 0 && index < existingUser.Notes.Count)
                {
                    existingUser.Notes[index] = note;
                    return true;
                }
            }
            return false;
        }

        public bool DeleteNote(UserRecord user, string index)
        {
            foreach (var existingUser in users)
            {
                if (string.Equals(existingUser.Name, user.Name, StringComparison.OrdinalIgnoreCase))

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