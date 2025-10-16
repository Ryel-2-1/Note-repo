namespace NoteApp1
{
    internal static class Program
    {
      
        [STAThread]
        static void Main()
        {
            
            https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginNew loginForm = new LoginNew())
            {
                var result = loginForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string username = loginForm.EnteredUsername;

                    
                    Application.Run(new Form1(username));
                }
                else
                {
                    Application.Exit();
                }

            }
        }
    }
}