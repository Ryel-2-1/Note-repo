using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Note.Data;

namespace Note.Business
{
    public class NoteProcess
    {
        private static List<UserName> users = new List<UserName>();
        private static UserName currentUser;

        public static void RegisterOrLoadUser(string name)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name == name)
                {
                    currentUser = users[i];
                    return;
                }
            }

            UserName newUser = new UserName();
            newUser.Name = name;
            users.Add(newUser);
            currentUser = newUser;
        }

        public static bool UpdateNotes(Actions userAction, string input = null)
        {
            if (currentUser == null) return false;

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

        public static bool UpdateNote(string indexStr, string newContent)
        {
            int index;
            if (!int.TryParse(indexStr, out index) || index < 1 || index > currentUser.Notes.Count)
            {
                return false;
            }

            currentUser.Notes[index - 1] = newContent;
            return true;
        }

        public static List<string> GetNotes()
        {
            if (currentUser == null) return new List<string>();
            return currentUser.Notes;
        }

        public static bool HasNotes()
        {
            return currentUser != null && currentUser.Notes.Count > 0;
        }
    }
}
