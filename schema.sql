-- ==============================================================================
-- LIBRARY MANAGEMENT SYSTEM - SQLITE DATABASE SCHEMA & SEED DATA
-- Enterprise Database Schema with 3-Tier Hierarchy (Admin, Librarian, User)
-- ==============================================================================

CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT UNIQUE NOT NULL,
    PasswordHash TEXT NOT NULL,
    FullName TEXT NOT NULL,
    Email TEXT,
    Role TEXT NOT NULL CHECK(Role IN ('Admin', 'Librarian', 'User')),
    IsActive INTEGER NOT NULL DEFAULT 1,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS Categories (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE NOT NULL,
    Description TEXT
);

CREATE TABLE IF NOT EXISTS Members (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    MemberCode TEXT UNIQUE NOT NULL,
    FullName TEXT NOT NULL,
    Email TEXT,
    Phone TEXT,
    Address TEXT,
    MemberType TEXT NOT NULL DEFAULT 'Student',
    Status TEXT NOT NULL DEFAULT 'Active',
    RegisteredAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS Books (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ISBN TEXT UNIQUE NOT NULL,
    Title TEXT NOT NULL,
    Author TEXT NOT NULL,
    Category TEXT NOT NULL,
    Publisher TEXT,
    PublishYear INTEGER DEFAULT 2024,
    TotalCopies INTEGER NOT NULL DEFAULT 1,
    AvailableCopies INTEGER NOT NULL DEFAULT 1,
    ShelfLocation TEXT DEFAULT 'A-01',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS Transactions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TransactionCode TEXT UNIQUE NOT NULL,
    BookId INTEGER NOT NULL,
    MemberId INTEGER NOT NULL,
    IssuedByUserId INTEGER NOT NULL,
    IssueDate DATETIME NOT NULL,
    DueDate DATETIME NOT NULL,
    ReturnDate DATETIME,
    Status TEXT NOT NULL CHECK(Status IN ('Borrowed', 'Returned', 'Overdue')),
    FineAmount REAL DEFAULT 0.0,
    FinePaid REAL DEFAULT 0.0,
    Notes TEXT,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(BookId) REFERENCES Books(Id),
    FOREIGN KEY(MemberId) REFERENCES Members(Id),
    FOREIGN KEY(IssuedByUserId) REFERENCES Users(Id)
);

CREATE INDEX IF NOT EXISTS idx_books_isbn ON Books(ISBN);
CREATE INDEX IF NOT EXISTS idx_members_code ON Members(MemberCode);
CREATE INDEX IF NOT EXISTS idx_trans_status ON Transactions(Status);

-- ==============================================================================
-- DEFAULT SEED DATA
-- Passwords are plain text or SHA-256 for easy first-time access.
-- Default logins:
-- 1. admin     / admin123  (Administrator)
-- 2. librarian / lib123    (Librarian Staff)
-- 3. user      / user123   (Patron / Student)
-- ==============================================================================

INSERT OR IGNORE INTO Users (Username, PasswordHash, FullName, Email, Role, IsActive)
VALUES 
('admin', 'admin123', 'Victoria Sterling (Admin)', 'admin@library.enterprise', 'Admin', 1),
('librarian', 'lib123', 'Genevieve Rose (Librarian)', 'librarian@library.enterprise', 'Librarian', 1),
('user', 'user123', 'Alexander Wright (Patron)', 'user@library.enterprise', 'User', 1);

INSERT OR IGNORE INTO Categories (Name, Description)
VALUES
('Computer Science', 'Software engineering, algorithms, AI, and systems architecture'),
('Literature & Fiction', 'Classic and contemporary literature, poetry, and novels'),
('Science & Technology', 'Physics, mathematics, chemistry, and modern biology'),
('Business & Management', 'Finance, leadership, economics, and entrepreneurship'),
('History & Social Sciences', 'World civilizations, archaeology, and global cultures');

INSERT OR IGNORE INTO Members (MemberCode, FullName, Email, Phone, Address, MemberType, Status)
VALUES
('LIB-M1001', 'Alexander Wright', 'user@library.enterprise', '+1-555-0192', '742 Evergreen Terrace, Springfield', 'Student', 'Active'),
('LIB-M1002', 'Dr. Sarah Jenkins', 's.jenkins@university.edu', '+1-555-0143', '100 University Avenue, Cambridge', 'Faculty', 'Active'),
('LIB-M1003', 'Liam Montgomery', 'liam.m@domain.com', '+1-555-0811', '89 Park Lane, Westminster', 'Public', 'Active'),
('LIB-M1004', 'Evelyn Hart', 'evelyn.h@college.edu', '+1-555-0922', '42 Maple Street, Boston', 'Student', 'Active');

INSERT OR IGNORE INTO Books (ISBN, Title, Author, Category, Publisher, PublishYear, TotalCopies, AvailableCopies, ShelfLocation)
VALUES
('978-0132350884', 'Clean Code: A Handbook of Agile Software Craftsmanship', 'Robert C. Martin', 'Computer Science', 'Prentice Hall', 2008, 5, 4, 'CS-A01'),
('978-0201616224', 'The Pragmatic Programmer: Your Journey to Mastery', 'Andrew Hunt & David Thomas', 'Computer Science', 'Addison-Wesley', 2019, 4, 3, 'CS-A02'),
('978-0262033848', 'Introduction to Algorithms (4th Edition)', 'Thomas H. Cormen', 'Computer Science', 'MIT Press', 2022, 6, 5, 'CS-B01'),
('978-0743273565', 'The Great Gatsby', 'F. Scott Fitzgerald', 'Literature & Fiction', 'Scribner', 2004, 8, 7, 'LIT-F03'),
('978-0061120084', 'To Kill a Mockingbird', 'Harper Lee', 'Literature & Fiction', 'Harper Perennial', 2006, 6, 6, 'LIT-F04'),
('978-0062316097', 'Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 'History & Social Sciences', 'Harper', 2015, 5, 4, 'HIST-H02'),
('978-0374533557', 'Thinking, Fast and Slow', 'Daniel Kahneman', 'Business & Management', 'Farrar, Straus and Giroux', 2011, 4, 4, 'BUS-M05'),
('978-0134685991', 'Effective Java (3rd Edition)', 'Joshua Bloch', 'Computer Science', 'Addison-Wesley', 2018, 5, 4, 'CS-A05');

INSERT OR IGNORE INTO Transactions (TransactionCode, BookId, MemberId, IssuedByUserId, IssueDate, DueDate, ReturnDate, Status, FineAmount, FinePaid, Notes)
VALUES
('TRX-2026-0001', 1, 1, 1, date('now', '-10 days'), date('now', '+4 days'), NULL, 'Borrowed', 0.0, 0.0, 'Regular student loan'),
('TRX-2026-0002', 2, 2, 2, date('now', '-20 days'), date('now', '-6 days'), NULL, 'Overdue', 0.0, 0.0, 'Overdue loan'),
('TRX-2026-0003', 6, 3, 2, date('now', '-30 days'), date('now', '-16 days'), date('now', '-15 days'), 'Returned', 0.0, 0.0, 'Completed loan return');
