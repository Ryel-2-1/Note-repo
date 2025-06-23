using NoteCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteDataService
{
    public interface INoteDataService
    {
        List<UserRecord> GetUsers();
        void CreateUser(UserRecord user);
        bool AddNote(UserRecord user);
        bool UpdateNotes(string user, int index, string note);
        bool DeleteNote(UserRecord user, string index);
    }

}