using C969_Project.Database;

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

            //Initialize Database
            DatabaseManager.StartConnection();

            Application.Run(new MainForm());

            //End DatabaseConnection
            DatabaseManager.EndConnection();
        }
    }
}