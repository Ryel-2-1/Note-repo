using NoteCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteDataService
{
    public class NoteDataService
    {
         INoteDataService dataService;

        public NoteDataService()
        {
            //dataService = new InMemoryNoteDataService(); 
            // dataService = new TextFileNoteDataService();
             dataService = new JsonFileNoteDataService();
        }

        public List<UserRecord> GetAllUsers()
        {
            return dataService.GetUsers();
        }
        public void AddUser(UserRecord user)
        {
            dataService.CreateUser(user);
        }
        public void UpdateUser(UserRecord user)
        {
            dataService.UpdateUser(user);
        }
        public void RemoveUser(UserRecord user)
        {
            dataService.RemoveUser(user);
        }
    }
}