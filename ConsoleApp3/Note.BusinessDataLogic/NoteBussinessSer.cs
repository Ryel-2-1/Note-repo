using Note.Data;
using NoteCommon;
using System.Collections.Generic;
using NoteDataService;
namespace NoteService
{
    public class NoteBussinessSer
    {
        string currentUser = null;
        NoteDataService.NoteDataService dataService = new NoteDataService.NoteDataService();

        public List<UserRecord> GetUserRecords()
        {
            return dataService.GetAllUsers();
        }
        public List<string> GetCurrentUserNote(string user)
        {
            foreach (var users in GetUserRecords())
            {
                if (users.Name == user)
                {
                    return users.Notes;
                }
            }
            return null;
        }
        public bool UpdateNotes(Actions userAction, string user, string input)
        {
            currentUser = user;
            if (currentUser == null)
                return false;

            if (userAction == Actions.AddNote)
            {
                var userData = new UserRecord
                {
                    Name = currentUser
                };
                userData.Notes.Add(input);
                return dataService.AddNote(userData);
            }

            if (userAction == Actions.DeleteNote)
            {
                var userData = new UserRecord
                {
                    Name = currentUser
                };

                return dataService.DeleteNote(userData, input);
            }
            return false;
        }

        public bool UpdateNotes(string user, int index, string input)
        {
            index--;
            return dataService.UpdateNote(user, index, input);

        }
        public void RegisterOrLoadUser(string user)
        {

            bool userExist = false;
            foreach (var users in GetUserRecords())
            {
                if (users.Name == user)
                {
                    currentUser = user;
                    userExist = true;
                }

            }
            if (!userExist)
            {
                currentUser = user;
                var userData = new UserRecord
                {
                    Name = currentUser
                };
                dataService.AddUser(userData);

            }
        }
        public bool HasNotes(string user)
        {
            var userNotes = GetCurrentUserNote(user);
            return userNotes != null && userNotes.Count > 0;
        }
    }
}