
using NoteService;
using NoteCommon;
using NoteDataService;
using Note.Data;

namespace NoteApp1
{
    public partial class Form1 : Form

    {
        NoteBussinessSer noteService;
        private string currentUser;
        public Form1(string userName)
        {
            InitializeComponent();
            currentUser = userName;
            noteService = new NoteBussinessSer();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            noteService.RegisterOrLoadUser(currentUser);
            lblLoggedInUser.Text = "Logged in as: " + currentUser;
            LoadNotes();

            lblLoggedInUser.Text = "Welcome, " + currentUser;

        }

     /*   private void Login()
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "Login", "");

            if (!string.IsNullOrWhiteSpace(name))
            {
                currentUser = name;
                noteService.RegisterOrLoadUser(currentUser);
                lblLoggedInUser.Text = $"Logged in as: {currentUser}";
                LoadNotes();
            }
            else
            {
                MessageBox.Show("Name is required.");
                Application.Exit();
            }
     }
    */    

        private void LoadNotes()
        {
            lstNotes.Items.Clear();

            var notes = noteService.GetCurrentUserNote(currentUser);
            if (notes != null)
            {
                foreach (var note in notes)
                {
                    lstNotes.Items.Add(note);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //btnswitch, cant modify nag eerror

        {
            this.Hide();
            LoginNew loginForm = new LoginNew();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                string newUser = loginForm.EnteredUsername;
                Form1 newMain = new Form1(newUser);
                newMain.Show();
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new note:", "Add Note", "");

            if (!string.IsNullOrWhiteSpace(input))
            {
                bool success = noteService.UpdateNotes(Actions.AddNote, currentUser, input);
                if (success)
                {
                    lblStatus.Text = "Note added successfully!";
                    lblStatus.ForeColor = Color.Green;
                    LoadNotes();
                }
                else
                {
                    lblStatus.Text = "Failed to add note.";
                    lblStatus.ForeColor = Color.Red;
                }
            }
        }

        private void btnUpdateNote_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex >= 0)
            {
                int index = lstNotes.SelectedIndex + 1;
                string newContent = Microsoft.VisualBasic.Interaction.InputBox("Edit note:", "Update Note", lstNotes.SelectedItem.ToString());

                if (!string.IsNullOrWhiteSpace(newContent))
                {
                    bool success = noteService.UpdateNotes(currentUser, index, newContent);
                    if (success)
                    {
                        lblStatus.Text = "Note updated.";
                        LoadNotes();
                    }
                    else
                    {
                        lblStatus.Text = "Update failed.";
                    }
                }
            }
            else
            {
                lblStatus.Text = "Select a note first.";
            }
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex >= 0)
            {
                int index = lstNotes.SelectedIndex + 1; 
                bool success = noteService.UpdateNotes(Actions.DeleteNote, currentUser, index.ToString());

                if (success)
                {
                    lblStatus.Text = "Note deleted.";
                    LoadNotes();
                }
                else
                {
                    lblStatus.Text = "Failed to delete note.";
                }
            }
            else
            {
                lblStatus.Text = "Select a note first.";
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (lstNotes.Items.Count > 0)
            {
                string allNotes = string.Join(Environment.NewLine, lstNotes.Items.Cast<string>());
                MessageBox.Show(allNotes, "All Notes");
            }
            else
            {
                MessageBox.Show("No notes to display.");
            }
        }
        /*       private void LoadNotes()
               {
                   lstNotes.Items.Clear();

                  var notes = noteService.GetCurrentUserNote(currentUserName);
                   foreach (var note in notes)
                   {
                       lstNotes.Items.Add(note);
                   }
                }
           */



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
