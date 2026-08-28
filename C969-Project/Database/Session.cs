namespace C969_Project.Database
{
    public static class Session
    {
        public static string CurrentUserName { get; private set; } = string.Empty;
        public static int CurrentUserId { get; private set; }

        public static void Start(string username, int userId)
        {
            CurrentUserId = userId;
            CurrentUserName = username;
        }

        public static void Clear()
        {
            CurrentUserId = 0;
            CurrentUserName = string.Empty;
        }
    }
}
