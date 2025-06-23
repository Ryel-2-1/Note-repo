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
            users.Add(new UserRecord { Name = "Alice", Notes = new List<string> { "buy groceries", "play games" } });
            users.Add(new UserRecord { Name = "Bob", Notes = new List<string> { "wash the dishes", "pending backlogs" } });
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
                if (existingUser.Name == user.Name)
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
                if (existingUser.Name == user && index >= 0 && index < existingUser.Notes.Count)
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