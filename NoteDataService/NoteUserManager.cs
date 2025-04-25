using NoteCommon;
using System.Collections.Generic;
using System.Linq;

namespace NoteDataService
{
    public class NoteUserManager
    {
        private List<UserRecord> users = new List<UserRecord>(); 
        private UserRecord currentUser;

        public NoteUserManager()
        {
            CreateDummyUsernames();
        }

        private void CreateDummyUsernames()
        {
            users.Add(new UserRecord { Name = "Alice", Notes = new List<string> { "buy groceries", "play games" } });
            users.Add(new UserRecord { Name = "Bob", Notes = new List<string> { "wash the dishes", "pending backlogs" } });
            users.Add(new UserRecord { Name = "Charlie", Notes = new List<string> { "feed the dogs", "watch a movie" } });
            users.Add(new UserRecord { Name = "Diana", Notes = new List<string> { "classes at 7:30", "repair laptop" } });
        }

        public UserRecord RegisterOrLoadUser(string name)
        {
           
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    currentUser = user;
                    return user;
                }
            }

            
            UserRecord newRecord = new UserRecord { Name = name };
            users.Add(newRecord);
            currentUser = newRecord;
            return newRecord;
        }
    }
}
