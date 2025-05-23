using NoteCommon;
using System.Collections.Generic;
using System.Linq;

namespace NoteDataService 
{
    public class NoteUserManager
    {
        private NoteDataService noteDataService = new NoteDataService();
        private UserRecord currentUser;




        public UserRecord RegisterOrLoadUser(string name)
        {
            var users = noteDataService.GetAllUsers();

            
            foreach (var user in users)
            {
                if (user.Name.Trim().ToLower() == name.Trim().ToLower())
                {
                    currentUser = user;
                    return user;
                }
            }

            UserRecord newUser = new UserRecord();
            newUser.Name = name.Trim();
            newUser.Notes = new List<string>();

            users.Add(newUser);           
            noteDataService.AddUser(newUser);  

            currentUser = newUser;
            return newUser;
        }

    }
}
