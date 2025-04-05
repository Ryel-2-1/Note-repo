﻿namespace Note.BusinessDataLogic
{
    public class NoteProcess
    {
        public static List<string> notes = new List<string>();

        public static bool UpdateNotes(Actions userAction, string input = null)
        {
            if (userAction == Actions.AddNote && !string.IsNullOrWhiteSpace(input))
            {
                notes.Add(input);
                return true;
            }

            if (userAction == Actions.DeleteNote && notes.Count > 0 &&
                int.TryParse(input, out int index) && index >= 1 && index <= notes.Count)
            {
                notes.RemoveAt(index - 1);
                return true;
            }

            return false;
        }

        public static bool UpdateNote(string indexStr, string newContent)
        {
            if (!int.TryParse(indexStr, out int index) || index < 1 || index > notes.Count)
            {
                return false; 
            }

            notes[index - 1] = newContent; 
            return true;
        }

        public static List<string> GetNotes()
        {
            return notes;
        }

        public static bool HasNotes()
        {
            return notes.Count > 0;
        }
    }
}
