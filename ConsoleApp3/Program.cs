using Note.Data;
using NoteCommon;
using NoteDataService;
using NoteService;
using Microsoft.Extensions.Configuration;

namespace NoteApp
{
    internal class Program
    {
        
        static NoteBussinessSer noteService = new NoteBussinessSer();

        static string userName;
        static string[] actions = new string[]
        {
            "[1] Add Note", "[2] Remove Note", "[3] View All Notes",
            "[4] Update Note", "[5] Exit", "[6] Switch Account"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is a note-taking program.");

            Login();
            DisplayActions();

            int userInput = GetUserInput();

            while ((Actions)userInput != Actions.Exit)
            {
                switch ((Actions)userInput)
                {
                    case Actions.AddNote:
                        Console.Write("What's on your mind? \n \t");
                        string note = Console.ReadLine();
                        if (noteService.UpdateNotes(Actions.AddNote, userName, note))
                        {
                            Console.WriteLine("Got it!");
                        }
                        break;


                    case Actions.DeleteNote:

                        ShowNotes();
                        Console.WriteLine("Which number of the note do you want to delete: ");
                        string input = Console.ReadLine();
                        if (noteService.UpdateNotes(Actions.DeleteNote, userName, input))
                        {
                            Console.WriteLine("Note deleted successfully.");
                        }
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
            noteService.RegisterOrLoadUser(userName);
            Console.WriteLine("Good day! " + userName);
            
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

            if (noteService.HasNotes(userName))
            {
                int i = 1;
                foreach (var note in noteService.GetCurrentUserNote(userName))
                {
                    Console.WriteLine(i + ". " + note);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("You have no notes yet.");

            }
        }
        static void HandleUpdateNote()
        {
            ShowNotes();
            Console.Write("Enter the number of the note you want to update: ");
            int input = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter the new content for the note: ");
            string newContent = Console.ReadLine();

            bool success = noteService.UpdateNotes(userName, input, newContent);
            if (success)
            {
                Console.WriteLine("Note updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid note number.");
            }

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