using System;

namespace LibraryManagementSystem
{
    public enum UserRole
    {
        Admin,
        Librarian,
        User
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class Member
    {
        public int Id { get; set; }
        public string MemberCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MemberType { get; set; } = "Student"; // Student, Faculty, Public
        public string Status { get; set; } = "Active";       // Active, Suspended, Expired
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
    }

    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = "General";
        public string Publisher { get; set; } = string.Empty;
        public int PublishYear { get; set; } = DateTime.Now.Year;
        public int TotalCopies { get; set; } = 1;
        public int AvailableCopies { get; set; } = 1;
        public string ShelfLocation { get; set; } = "A-01";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class LibraryTransaction
    {
        public int Id { get; set; }
        public string TransactionCode { get; set; } = string.Empty;
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public int IssuedByUserId { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "Borrowed"; // Borrowed, Returned, Overdue
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class TransactionDetailView
    {
        public int Id { get; set; }
        public string TransactionCode { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;
        public string MemberCode { get; set; } = string.Empty;
        public string IssueDate { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string ReturnDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string IssuerName { get; set; } = string.Empty;
    }

    public class DashboardStats
    {
        public int TotalBooks { get; set; }
        public int AvailableBooks { get; set; }
        public int BorrowedBooks { get; set; }
        public int OverdueBooks { get; set; }
        public int TotalMembers { get; set; }
        public int TotalUsers { get; set; }
        public int TotalReturned { get; set; }
    }

    public class UserDashboardStats
    {
        public int MyBorrowedBooks { get; set; }
        public int MyOverdueBooks { get; set; }
        public int MyTotalHistory { get; set; }
        public int TotalCatalogAvailable { get; set; }
    }
}

