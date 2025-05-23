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

        public void RemoveUser(UserRecord user)
        {
            users.RemoveAll(u => u.Name == user.Name);
        }

        public void UpdateUser(UserRecord user)
        {
            var index = users.FindIndex(u => u.Name == user.Name);
            if (index != -1)
            {
                users[index] = user;
            }
        }
    }
}
