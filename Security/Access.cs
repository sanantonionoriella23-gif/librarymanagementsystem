using System;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Role-Based Access Control (RBAC) engine for the 3-tier hierarchy:
    /// 1. Admin: Full system control, user accounts, audit trails, and configuration.
    /// 2. Librarian: Operational control over book catalog, members, circulation desk.
    /// 3. User (Patron): Self-service catalog browsing, viewing personal loans and QR card.
    /// </summary>
    public static class Access
    {
        public static bool CanManageUsers(UserRole role)
        {
            return role == UserRole.Admin;
        }

        public static bool CanAddBooks(UserRole role)
        {
            // Admin, Librarian, and Users (Students) can add books to the catalog
            return true;
        }

        public static bool CanManageBooks(UserRole role)
        {
            return role == UserRole.Admin || role == UserRole.Librarian;
        }

        public static bool CanDeleteBooks(UserRole role)
        {
            return role == UserRole.Admin;
        }

        public static bool CanManageMembers(UserRole role)
        {
            return role == UserRole.Admin || role == UserRole.Librarian;
        }

        public static bool CanIssueAndReturn(UserRole role)
        {
            return role == UserRole.Admin || role == UserRole.Librarian;
        }

        public static bool CanViewAllHistory(UserRole role)
        {
            return role == UserRole.Admin || role == UserRole.Librarian;
        }

        public static bool CanExportReports(UserRole role)
        {
            return role == UserRole.Admin || role == UserRole.Librarian;
        }

        public static string GetRoleBadge(UserRole role)
        {
            switch (role)
            {
                case UserRole.Admin:
                    return "System Administrator";
                case UserRole.Librarian:
                    return "Library Staff";
                case UserRole.User:
                    return "Library Member / Patron";
                default:
                    return "Guest";
            }
        }
    }
}

