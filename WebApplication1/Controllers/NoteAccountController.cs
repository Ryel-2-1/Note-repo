using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using Note.Data;
using NoteCommon;
using NoteService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteAccountController : ControllerBase
    {
        NoteBussinessSer noteBS = new NoteBussinessSer();
        [HttpGet]
        public IEnumerable<UserRecord> GetAccount()
        {
            var account = noteBS.GetUserRecords();

            return account;
        }
       

        [HttpPatch("AddNote")]
        public bool AddNote( string user, string input)
        {
            var actions = Actions.AddNote;

            var result = noteBS.UpdateNotes(actions, user, input);

            return result;
        }

        [HttpDelete("DeleteNote")]
        public bool DeleteNote(string user, string input)
        {
            var actions = Actions.DeleteNote;

            var result = noteBS.UpdateNotes(actions, user, input);

            return result;
        }

        [HttpPatch("UpdateNote")]
        
        public bool UpdateNote(string user, int index, string input)
        {
            return noteBS.UpdateNotes(user,index,input);
        }

        [HttpPost("CreateAccount")]

        public void CreateAccount(string user)
        {
            noteBS.RegisterOrLoadUser(user);
        }
    }

}
