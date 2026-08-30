using C969_Project.Database;
using C969_Project.Forms;

namespace C969_Project
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

            //Clear our current session
            Session.Clear();

            //Initialize Database
            DatabaseManager.StartConnection();

            //Verify Login

            try
            {
                using var loginForm = new LoginForm();

                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                //Run the actual app now assuming login is good
                Application.Run(new MainForm());
            }
            finally
            {
                //End DatabaseConnection
                DatabaseManager.EndConnection();
                Session.Clear();
            }

        }
    }
}