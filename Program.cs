using System;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Configure DPI awareness, font smoothing, and modern visual styles
            ApplicationConfiguration.Initialize();

            try
            {
                // Ensure SQLite database and default seed records are ready
                Database.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Initialization Error: " + ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Headless initialization flag for automated verification
            if (args != null && args.Length > 0 && args[0] == "--init-only")
            {
                var stats = Database.GetDashboardStats();
                Console.WriteLine($"DB_READY: TotalBooks={stats.TotalBooks}, Members={stats.TotalMembers}, Borrowed={stats.BorrowedBooks}, Overdue={stats.OverdueBooks}");
                return;
            }

            // Launch the secure multi-tier authentication portal
            Application.Run(new LoginForm());
        }
    }
}
