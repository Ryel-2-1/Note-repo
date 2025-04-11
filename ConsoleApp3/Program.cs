using Note.Data;
using NoteCommon;     
using NoteDataService;
using NoteService;

internal class Program
{
    static string[] actions = new string[]
    {
        "[1] Add Note", "[2] Remove Note", "[3] View All Notes",
        "[4] Update Note", "[5] Exit", "[6] Switch Account"
    };

    static void Main(string[] args)
    {
        NoteUserManager noteUserManager = new NoteUserManager(); 

        UserRecord currentUser = LoadUser(noteUserManager); 
        NoteBussinessSer noteService = new NoteBussinessSer(currentUser); 

        while (true)
        {
            DisplayActions(currentUser.Name); // Display actions for current user
            int userInput = GetUserInput(); // Get user input

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
                    ShowNotes(noteService);
                    Console.WriteLine("Which number of the note do you want to delete: ");
                    string input = Console.ReadLine();
                    if (noteService.UpdateNotes(Actions.DeleteNote, input))
                        Console.WriteLine("Note deleted successfully.");
                    else
                        Console.WriteLine("Invalid note number.");
                    break;

                case Actions.ViewNotes:
                    ShowNotes(noteService);
                    break;

                case Actions.UpdateNote:
                    HandleUpdateNote(noteService);
                    break;

                case Actions.Exit:
                    ExitInvalid((int)Actions.Exit);
                    Environment.Exit(0);
                    break;

                case Actions.SwitchAccount:
                    currentUser = LoadUser(noteUserManager); 
                    noteService = new NoteBussinessSer(currentUser); 
                    break;

                default:
                    ExitInvalid(userInput);
                    break;
            }
        }
    }

    static UserRecord LoadUser(NoteUserManager noteUserManager)
    {
        string name = GetName();
        UserRecord user = noteUserManager.RegisterOrLoadUser(name); 
        DisplayName(name);
        return user;
    }

    static void DisplayActions(string name)
    {
        Console.WriteLine("================");
        Console.WriteLine("What would you like to do, " + name + "?");
        foreach (var action in actions)
            Console.WriteLine(action);
    }

    static void ShowNotes(NoteBussinessSer noteService)
    {
        if (!noteService.HasNotes())
            Console.WriteLine("No notes");
        else
        {
            List<string> notes = noteService.GetNotes();
            Console.WriteLine("Your notes:");
            for (int i = 0; i < notes.Count; i++)
                Console.WriteLine((i + 1) + ": " + notes[i]);
        }
    }

    static void HandleUpdateNote(NoteBussinessSer noteService)
    {
        if (!noteService.HasNotes())
        {
            Console.WriteLine("No notes to update.");
            return;
        }

        ShowNotes(noteService);
        Console.Write("Enter the number of the note you want to update: ");
        string input = Console.ReadLine();
        Console.Write("Enter the new content for the note: ");
        string newContent = Console.ReadLine();

        bool success = noteService.UpdateNote(input, newContent);
        Console.WriteLine(success ? "Note updated successfully." : "Invalid note number.");
    }

    static int GetUserInput()
    {
        while (true)
        {
            Console.Write("[User Input]: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int userInput) && System.Enum.IsDefined(typeof(Actions), userInput))
                return userInput;
            else
                Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    static void DisplayName(string name)
    {
        Console.WriteLine("Good day! " + name);
    }

    static string GetName()
    {
        Console.WriteLine("Hello, this is a note-taking program.");
        Console.WriteLine("What is your name?");
        return Console.ReadLine();
    }

    static void ExitInvalid(int userAction)
    {
        if ((Actions)userAction == Actions.Exit)
            Console.WriteLine("CLOSING PROGRAM...");
        else
            Console.WriteLine("Invalid option. Please choose again.");
    }
}
