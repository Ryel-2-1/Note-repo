using Note.Data;
using NoteCommon;
using NoteDataService;
using NoteService;

namespace NoteApp
{
    internal class Program
    {
        static string userName = string.Empty;
        static NoteUserManager noteUserManager = new NoteUserManager();
        static NoteBussinessSer noteService;

        static string[] actions = new string[]
        {
            "[1] Add Note", "[2] Remove Note", "[3] View All Notes",
            "[4] Update Note", "[5] Exit", "[6] Switch Account"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is a note-taking program.");

            Login(); 

            int userInput = GetUserInput();

            while ((Actions)userInput != Actions.Exit)
            {
                switch ((Actions)userInput)
                {
                    case Actions.AddNote:
                        Console.Write("What's on your mind? \n \t");
                        string note = Console.ReadLine();
                        if (noteService.UpdateNotes(Actions.AddNote, note))
                            Console.WriteLine("Got it!");
                        break;

                    case Actions.DeleteNote:
                        if (!noteService.HasNotes())
                        {
                            Console.WriteLine("No notes to delete.");
                            break;
                        }
                        ShowNotes();
                        Console.WriteLine("Which number of the note do you want to delete: ");
                        string input = Console.ReadLine();
                        if (noteService.UpdateNotes(Actions.DeleteNote, input))
                            Console.WriteLine("Note deleted successfully.");
                        else
                            Console.WriteLine("Invalid note number.");
                        break;

                    case Actions.ViewNotes:
                        ShowNotes();
                        break;

                    case Actions.UpdateNote:
                        HandleUpdateNote();
                        break;

                    case Actions.SwitchAccount:
                        Login();
                        break;

                    default:
                        ExitInvalid(userInput);
                        break;
                }

                DisplayActions();
                userInput = GetUserInput();
            }

            Console.WriteLine("CLOSING PROGRAM...");
        }

        static void Login()
        {
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();

            UserRecord user = noteUserManager.RegisterOrLoadUser(userName);
            noteService = new NoteBussinessSer(user);

            Console.WriteLine("Good day! " + userName);
            DisplayActions();
        }

        static void DisplayActions()
        {
            Console.WriteLine("================");
            Console.WriteLine("What would you like to do, " + userName + "?");
            foreach (var action in actions)
                Console.WriteLine(action);
        }

        static int GetUserInput()
        {
            while (true)
            {
                Console.Write("[User Input]: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int userInput) &&
                    Enum.IsDefined(typeof(Actions), userInput))
                    return userInput;
                else
                    Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }

        static void ShowNotes()
        {
            if (!noteService.HasNotes())
            {
                Console.WriteLine("No notes");
            }
            else
            {
                List<string> notes = noteService.GetNotes();
                Console.WriteLine("Your notes:");
                for (int i = 0; i < notes.Count; i++)
                    Console.WriteLine((i + 1) + ": " + notes[i]);
            }
        }

        static void HandleUpdateNote()
        {
            if (!noteService.HasNotes())
            {
                Console.WriteLine("No notes to update.");
                return;
            }

            ShowNotes();
            Console.Write("Enter the number of the note you want to update: ");
            string input = Console.ReadLine();
            Console.Write("Enter the new content for the note: ");
            string newContent = Console.ReadLine();

            bool success = noteService.UpdateNote(input, newContent);
            Console.WriteLine(success ? "Note updated successfully." : "Invalid note number.");
        }

        static void ExitInvalid(int userAction)
        {
            if ((Actions)userAction == Actions.Exit)
                Console.WriteLine("CLOSING PROGRAM...");
            else
                Console.WriteLine("Invalid option. Please choose again.");
        }
    }
}
