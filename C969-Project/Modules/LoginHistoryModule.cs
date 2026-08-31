using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace C969_Project.Modules
{
    public static class LoginHistoryModule
    {
        private const string FileName = "Login_History.txt";

        public static void RecordLogin(string username)
        {
            string FilePath = Path.Combine(AppContext.BaseDirectory, FileName);
            string FileEntry = $"Login Time UTC: {DateTimeOffset.UtcNow.ToString("O", CultureInfo.InvariantCulture)} | Username: {username}{Environment.NewLine}";

            File.AppendAllText(FilePath, FileEntry);
        }
    }
}
