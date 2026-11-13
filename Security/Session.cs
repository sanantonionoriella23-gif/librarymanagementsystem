using System;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Global application session managing the currently authenticated user.
    /// </summary>
    public static class Session
    {
        public static User? CurrentUser { get; private set; }
        public static DateTime? LoginTime { get; private set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static void SetUser(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
            LoginTime = DateTime.Now;
        }

        public static void Clear()
        {
            CurrentUser = null;
            LoginTime = null;
        }

        public static bool IsAdmin => CurrentUser?.Role == UserRole.Admin;
        public static bool IsLibrarian => CurrentUser?.Role == UserRole.Librarian;
        public static bool IsUser => CurrentUser?.Role == UserRole.User;
    }
}

