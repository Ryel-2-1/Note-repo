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
        void CreateUser(UserRecord user);
        List<UserRecord> GetUsers();
        void RemoveUser(UserRecord user);
        void UpdateUser(UserRecord user);
        
    }

}
