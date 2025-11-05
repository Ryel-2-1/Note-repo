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
        private readonly NoteBussinessSer _noteService;

        public NoteAccountController(NoteBussinessSer noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IEnumerable<UserRecord> GetAccount()
        {
            var account = _noteService.GetUserRecords();

            return account;
        }
       

        [HttpPatch("AddNote")]
        public bool AddNote( string user, string input)
        {
            var actions = Actions.AddNote;

            var result = _noteService.UpdateNotes(actions, user, input);

            return result;
        }

        [HttpDelete("DeleteNote")]
        public bool DeleteNote(string user, string input)
        {
            var actions = Actions.DeleteNote;

            var result = _noteService.UpdateNotes(actions, user, input);

            return result;
        }

        [HttpPatch("UpdateNote")]
        
        public bool UpdateNote(string user, int index, string input)
        {
            return _noteService.UpdateNotes(user,index,input);
        }

        [HttpPost("CreateAccount")]

        public void CreateAccount(string user)
        {
            _noteService.RegisterOrLoadUser(user);
        }
    }

}
