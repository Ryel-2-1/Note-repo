namespace NoteApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
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