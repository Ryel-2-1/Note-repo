using Note.Data;
using NoteCommon;
using System.Collections.Generic;

namespace NoteService
{
    public class NoteBussinessSer
    {
        private UserRecord currentUser;

        public NoteBussinessSer(UserRecord currentUser)
        {
            this.currentUser = currentUser;
        }

        public bool UpdateNotes(Actions userAction, string input = null)
        {
            if (currentUser == null)
                return false;

            if (userAction == Actions.AddNote && !string.IsNullOrWhiteSpace(input))
            {
                currentUser.Notes.Add(input);
                return true;
            }

            if (userAction == Actions.DeleteNote && currentUser.Notes.Count > 0 &&
                int.TryParse(input, out int index) && index >= 1 && index <= currentUser.Notes.Count)
            {
                currentUser.Notes.RemoveAt(index - 1);
                return true;
            }

            return false;
        }

        public bool UpdateNote(string indexStr, string newContent)
        {
            if (!int.TryParse(indexStr, out int index) || index < 1 || index > currentUser.Notes.Count)
            {
                return false;
            }

            currentUser.Notes[index - 1] = newContent;
            return true;
        }

        public List<string> GetNotes()
        {
            return currentUser?.Notes ?? new List<string>();
        }

        public bool HasNotes()
        {
            return currentUser != null && currentUser.Notes.Count > 0;
        }
    }
}
