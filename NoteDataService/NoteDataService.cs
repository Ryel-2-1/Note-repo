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
           // dataService = new InMemoryNoteDataService(); 
          //  dataService = new TextFileNoteDataService();
          // dataService = new JsonFileNoteDataService();
           dataService = new DBDataService();
        }

        public List<UserRecord> GetAllUsers()
        {
            return dataService.GetUsers();
        }
        public bool AddNote(UserRecord user)
        {
            return dataService.AddNote(user);
        }
        public void AddUser(UserRecord user)
        {
            dataService.CreateUser(user);
        }
        public bool UpdateNote(string user, int index, string note)
        {
            return dataService.UpdateNotes(user, index, note);
        }
        public bool DeleteNote(UserRecord user, string index)
        {
            return dataService.DeleteNote(user, index);
        }
    }
}