using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;

namespace LibraryManagementSystem
{
    
    public static class Database
    {
        private static string _dbPath = "";
        private static string _connectionString = "";

        static Database()
        {
            InitializeDatabasePath();
        }

        public static string DatabasePath => _dbPath;

        private static void InitializeDatabasePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dbFolder = Path.Combine(baseDir, "Database");

            
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }

            _dbPath = Path.Combine(dbFolder, "library.db");
            _connectionString = $"Data Source={_dbPath};";
        }

        public static SqliteConnection GetConnection()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn;
        }

       
        public static void Initialize()
        {
            InitializeDatabasePath();

            bool dbExists = File.Exists(_dbPath) && new FileInfo(_dbPath).Length > 0;

            using (var conn = GetConnection())
            {
               
                string[] possiblePaths = new[]
                {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schema.sql"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "schema.sql"),
                    Path.Combine(Directory.GetCurrentDirectory(), "schema.sql"),
                    Path.Combine(Directory.GetCurrentDirectory(), "Data", "schema.sql")
                };

                string schemaSql = "";
                foreach (var path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        schemaSql = File.ReadAllText(path);
                        break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(schemaSql))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = schemaSql;
                        cmd.ExecuteNonQuery();
                    }
                }
            }

           
            UpdateOverdueStatuses();
        }

       

        public static User? Authenticate(string username, string password)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT Id, Username, PasswordHash, FullName, Email, Role, IsActive, CreatedAt 
                    FROM Users 
                    WHERE LOWER(Username) = LOWER(@Username) AND IsActive = 1;";
                cmd.Parameters.AddWithValue("@Username", username.Trim());

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader.GetString(2);
                        if (VerifyPassword(password, storedHash))
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                PasswordHash = storedHash,
                                FullName = reader.GetString(3),
                                Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Role = Enum.TryParse<UserRole>(reader.GetString(5), true, out var role) ? role : UserRole.User,
                                IsActive = reader.GetInt32(6) == 1,
                                CreatedAt = reader.GetDateTime(7)
                            };
                        }
                    }
                }
            }
            return null;
        }

        private static bool VerifyPassword(string inputPassword, string storedHash)
        {
            if (string.Equals(inputPassword, storedHash, StringComparison.Ordinal))
            {
                return true;
            }

            string computedHash = HashPassword(inputPassword);
            return string.Equals(computedHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }

        public static string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static List<User> GetUsers()
        {
            var list = new List<User>();
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Username, PasswordHash, FullName, Email, Role, IsActive, CreatedAt FROM Users ORDER BY Id ASC;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            PasswordHash = reader.GetString(2),
                            FullName = reader.GetString(3),
                            Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Role = Enum.TryParse<UserRole>(reader.GetString(5), true, out var role) ? role : UserRole.User,
                            IsActive = reader.GetInt32(6) == 1,
                            CreatedAt = reader.GetDateTime(7)
                        });
                    }
                }
            }
            return list;
        }

        public static bool AddUser(User user, string plainPassword)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Users (Username, PasswordHash, FullName, Email, Role, IsActive)
                    VALUES (@Username, @PasswordHash, @FullName, @Email, @Role, @IsActive);";
                cmd.Parameters.AddWithValue("@Username", user.Username.Trim());
                cmd.Parameters.AddWithValue("@PasswordHash", plainPassword);
                cmd.Parameters.AddWithValue("@FullName", user.FullName.Trim());
                cmd.Parameters.AddWithValue("@Email", user.Email?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Role", user.Role.ToString());
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive ? 1 : 0);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateUser(User user)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Users 
                    SET FullName = @FullName, Email = @Email, Role = @Role, IsActive = @IsActive
                    WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@FullName", user.FullName.Trim());
                cmd.Parameters.AddWithValue("@Email", user.Email?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Role", user.Role.ToString());
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive ? 1 : 0);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool ResetUserPassword(int userId, string newPassword)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Users SET PasswordHash = @Password WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteUser(int userId)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

       
        public static List<Book> GetBooks(string search = "", string category = "All")
        {
            var list = new List<Book>();
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                var sb = new StringBuilder("SELECT Id, ISBN, Title, Author, Category, Publisher, PublishYear, TotalCopies, AvailableCopies, ShelfLocation, CreatedAt FROM Books WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(search))
                {
                    sb.Append(" AND (LOWER(Title) LIKE @Search OR LOWER(Author) LIKE @Search OR LOWER(ISBN) LIKE @Search) ");
                    cmd.Parameters.AddWithValue("@Search", $"%{search.Trim().ToLower()}%");
                }

                if (!string.IsNullOrWhiteSpace(category) && category != "All" && category != "All Categories")
                {
                    sb.Append(" AND Category = @Category ");
                    cmd.Parameters.AddWithValue("@Category", category);
                }

                sb.Append(" ORDER BY Title ASC;");
                cmd.CommandText = sb.ToString();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            ISBN = reader.GetString(1),
                            Title = reader.GetString(2),
                            Author = reader.GetString(3),
                            Category = reader.GetString(4),
                            Publisher = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            PublishYear = reader.IsDBNull(6) ? 2024 : reader.GetInt32(6),
                            TotalCopies = reader.GetInt32(7),
                            AvailableCopies = reader.GetInt32(8),
                            ShelfLocation = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            CreatedAt = reader.GetDateTime(10)
                        });
                    }
                }
            }
            return list;
        }

        public static Book? GetBookById(int id)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, ISBN, Title, Author, Category, Publisher, PublishYear, TotalCopies, AvailableCopies, ShelfLocation, CreatedAt FROM Books WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            Id = reader.GetInt32(0),
                            ISBN = reader.GetString(1),
                            Title = reader.GetString(2),
                            Author = reader.GetString(3),
                            Category = reader.GetString(4),
                            Publisher = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            PublishYear = reader.IsDBNull(6) ? 2024 : reader.GetInt32(6),
                            TotalCopies = reader.GetInt32(7),
                            AvailableCopies = reader.GetInt32(8),
                            ShelfLocation = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            CreatedAt = reader.GetDateTime(10)
                        };
                    }
                }
            }
            return null;
        }

        public static Book? GetBookByIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) return null;
            string clean = isbn.Trim();
            string stripped = clean.Replace("-", "").Replace(" ", "");

            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT Id, ISBN, Title, Author, Category, Publisher, PublishYear, TotalCopies, AvailableCopies, ShelfLocation, CreatedAt 
                    FROM Books 
                    WHERE LOWER(ISBN) = LOWER(@ISBN) 
                       OR REPLACE(REPLACE(ISBN, '-', ''), ' ', '') = @Stripped
                    LIMIT 1;";
                cmd.Parameters.AddWithValue("@ISBN", clean);
                cmd.Parameters.AddWithValue("@Stripped", stripped);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            Id = reader.GetInt32(0),
                            ISBN = reader.GetString(1),
                            Title = reader.GetString(2),
                            Author = reader.GetString(3),
                            Category = reader.GetString(4),
                            Publisher = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            PublishYear = reader.IsDBNull(6) ? 2024 : reader.GetInt32(6),
                            TotalCopies = reader.GetInt32(7),
                            AvailableCopies = reader.GetInt32(8),
                            ShelfLocation = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            CreatedAt = reader.GetDateTime(10)
                        };
                    }
                }
            }
            return null;
        }

        public static bool AddBook(Book book)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Books (ISBN, Title, Author, Category, Publisher, PublishYear, TotalCopies, AvailableCopies, ShelfLocation)
                    VALUES (@ISBN, @Title, @Author, @Category, @Publisher, @PublishYear, @TotalCopies, @AvailableCopies, @ShelfLocation);";
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN.Trim());
                cmd.Parameters.AddWithValue("@Title", book.Title.Trim());
                cmd.Parameters.AddWithValue("@Author", book.Author.Trim());
                cmd.Parameters.AddWithValue("@Category", book.Category.Trim());
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@PublishYear", book.PublishYear);
                cmd.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
                cmd.Parameters.AddWithValue("@AvailableCopies", book.AvailableCopies);
                cmd.Parameters.AddWithValue("@ShelfLocation", book.ShelfLocation?.Trim() ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateBook(Book book)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Books 
                    SET ISBN = @ISBN, Title = @Title, Author = @Author, Category = @Category, 
                        Publisher = @Publisher, PublishYear = @PublishYear, 
                        TotalCopies = @TotalCopies, AvailableCopies = @AvailableCopies, ShelfLocation = @ShelfLocation
                    WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN.Trim());
                cmd.Parameters.AddWithValue("@Title", book.Title.Trim());
                cmd.Parameters.AddWithValue("@Author", book.Author.Trim());
                cmd.Parameters.AddWithValue("@Category", book.Category.Trim());
                cmd.Parameters.AddWithValue("@Publisher", book.Publisher?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@PublishYear", book.PublishYear);
                cmd.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
                cmd.Parameters.AddWithValue("@AvailableCopies", book.AvailableCopies);
                cmd.Parameters.AddWithValue("@ShelfLocation", book.ShelfLocation?.Trim() ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteBook(int bookId)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Books WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", bookId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static List<string> GetCategories()
        {
            var list = new List<string>();
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Name FROM Categories ORDER BY Name ASC;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }
            if (list.Count == 0)
            {
                list.AddRange(new[] { "Computer Science", "Literature & Fiction", "Science & Technology", "Business & Management", "History & Social Sciences" });
            }
            return list;
        }

       
        public static List<Member> GetMembers(string search = "")
        {
            var list = new List<Member>();
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                var sb = new StringBuilder("SELECT Id, MemberCode, FullName, Email, Phone, Address, MemberType, Status, RegisteredAt FROM Members WHERE 1=1 ");
                if (!string.IsNullOrWhiteSpace(search))
                {
                    sb.Append(" AND (LOWER(FullName) LIKE @Search OR LOWER(MemberCode) LIKE @Search OR LOWER(Email) LIKE @Search) ");
                    cmd.Parameters.AddWithValue("@Search", $"%{search.Trim().ToLower()}%");
                }
                sb.Append(" ORDER BY MemberCode ASC;");
                cmd.CommandText = sb.ToString();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Member
                        {
                            Id = reader.GetInt32(0),
                            MemberCode = reader.GetString(1),
                            FullName = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Address = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            MemberType = reader.GetString(6),
                            Status = reader.GetString(7),
                            RegisteredAt = reader.GetDateTime(8)
                        });
                    }
                }
            }
            return list;
        }

        public static Member? GetMemberByCode(string code)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, MemberCode, FullName, Email, Phone, Address, MemberType, Status, RegisteredAt FROM Members WHERE LOWER(MemberCode) = LOWER(@Code);";
                cmd.Parameters.AddWithValue("@Code", code.Trim());
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Member
                        {
                            Id = reader.GetInt32(0),
                            MemberCode = reader.GetString(1),
                            FullName = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Address = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            MemberType = reader.GetString(6),
                            Status = reader.GetString(7),
                            RegisteredAt = reader.GetDateTime(8)
                        };
                    }
                }
            }
            return null;
        }

        public static Member? GetMemberByEmail(string email)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, MemberCode, FullName, Email, Phone, Address, MemberType, Status, RegisteredAt FROM Members WHERE LOWER(Email) = LOWER(@Email);";
                cmd.Parameters.AddWithValue("@Email", email.Trim());
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Member
                        {
                            Id = reader.GetInt32(0),
                            MemberCode = reader.GetString(1),
                            FullName = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Address = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            MemberType = reader.GetString(6),
                            Status = reader.GetString(7),
                            RegisteredAt = reader.GetDateTime(8)
                        };
                    }
                }
            }
            return null;
        }

        public static bool AddMember(Member member)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Members (MemberCode, FullName, Email, Phone, Address, MemberType, Status)
                    VALUES (@MemberCode, @FullName, @Email, @Phone, @Address, @MemberType, @Status);";
                cmd.Parameters.AddWithValue("@MemberCode", member.MemberCode.Trim());
                cmd.Parameters.AddWithValue("@FullName", member.FullName.Trim());
                cmd.Parameters.AddWithValue("@Email", member.Email?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Phone", member.Phone?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Address", member.Address?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@MemberType", member.MemberType);
                cmd.Parameters.AddWithValue("@Status", member.Status);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateMember(Member member)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Members 
                    SET FullName = @FullName, Email = @Email, Phone = @Phone, 
                        Address = @Address, MemberType = @MemberType, Status = @Status
                    WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", member.Id);
                cmd.Parameters.AddWithValue("@FullName", member.FullName.Trim());
                cmd.Parameters.AddWithValue("@Email", member.Email?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Phone", member.Phone?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Address", member.Address?.Trim() ?? "");
                cmd.Parameters.AddWithValue("@MemberType", member.MemberType);
                cmd.Parameters.AddWithValue("@Status", member.Status);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteMember(int memberId)
        {
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Members WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@Id", memberId);
               return cmd.ExecuteNonQuery() > 0;
            }
        }

       

        public static (bool Success, string Message) IssueBook(int bookId, int memberId, int userId, int loanDays = 14, string notes = "")
        {
            using (var conn = GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                   
                    int availableCopies = 0;
                    using (var checkBook = conn.CreateCommand())
                    {
                        checkBook.Transaction = transaction;
                        checkBook.CommandText = "SELECT AvailableCopies FROM Books WHERE Id = @BookId;";
                        checkBook.Parameters.AddWithValue("@BookId", bookId);
                        var obj = checkBook.ExecuteScalar();
                        if (obj == null) return (false, "Book not found.");
                        availableCopies = Convert.ToInt32(obj);
                    }

                    if (availableCopies <= 0)
                    {
                        return (false, "This book has zero available copies remaining.");
                    }

                   
                    using (var checkMember = conn.CreateCommand())
                    {
                        checkMember.Transaction = transaction;
                        checkMember.CommandText = "SELECT Status FROM Members WHERE Id = @MemberId;";
                        checkMember.Parameters.AddWithValue("@MemberId", memberId);
                        var obj = checkMember.ExecuteScalar();
                        if (obj == null) return (false, "Member not found.");
                        if (obj.ToString() != "Active") return (false, $"Member is currently {obj.ToString()}. Circulation restricted.");
                    }

                    
                    using (var decBook = conn.CreateCommand())
                    {
                        decBook.Transaction = transaction;
                        decBook.CommandText = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE Id = @BookId;";
                        decBook.Parameters.AddWithValue("@BookId", bookId);
                        decBook.ExecuteNonQuery();
                    }

                   
                    string trxCode = $"TRX-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";
                    DateTime issueDate = DateTime.Now;
                    DateTime dueDate = issueDate.AddDays(loanDays);

                    using (var insertTrx = conn.CreateCommand())
                    {
                        insertTrx.Transaction = transaction;
                        insertTrx.CommandText = @"
                            INSERT INTO Transactions (TransactionCode, BookId, MemberId, IssuedByUserId, IssueDate, DueDate, Status, FineAmount, FinePaid, Notes)
                            VALUES (@TrxCode, @BookId, @MemberId, @UserId, @IssueDate, @DueDate, 'Borrowed', 0.0, 0.0, @Notes);";
                        insertTrx.Parameters.AddWithValue("@TrxCode", trxCode);
                        insertTrx.Parameters.AddWithValue("@BookId", bookId);
                        insertTrx.Parameters.AddWithValue("@MemberId", memberId);
                        insertTrx.Parameters.AddWithValue("@UserId", userId);
                        insertTrx.Parameters.AddWithValue("@IssueDate", issueDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        insertTrx.Parameters.AddWithValue("@DueDate", dueDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        insertTrx.Parameters.AddWithValue("@Notes", notes);
                        insertTrx.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return (true, $"Book successfully issued! Due date: {dueDate:MMM dd, yyyy}.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return (false, "Error issuing book: " + ex.Message);
                }
            }
        }

        public static (bool Success, string Message) ReturnBook(int transactionId, string returnNotes = "")
        {
            using (var conn = GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    int bookId = 0;
                    string status = "";

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        cmd.CommandText = "SELECT BookId, Status FROM Transactions WHERE Id = @Id;";
                        cmd.Parameters.AddWithValue("@Id", transactionId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read()) return (false, "Transaction not found.");
                            bookId = reader.GetInt32(0);
                            status = reader.GetString(1);
                        }
                    }

                    if (status == "Returned")
                    {
                        return (false, "This transaction has already been returned.");
                    }

                   
                    using (var updateTrx = conn.CreateCommand())
                    {
                        updateTrx.Transaction = transaction;
                        updateTrx.CommandText = @"
                            UPDATE Transactions 
                            SET Status = 'Returned', ReturnDate = @ReturnDate, Notes = COALESCE(Notes, '') || ' ' || @Notes
                            WHERE Id = @Id;";
                        updateTrx.Parameters.AddWithValue("@Id", transactionId);
                        updateTrx.Parameters.AddWithValue("@ReturnDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        updateTrx.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(returnNotes) ? "" : $"[Return: {returnNotes}]");
                        updateTrx.ExecuteNonQuery();
                    }

                   
                    using (var incBook = conn.CreateCommand())
                    {
                        incBook.Transaction = transaction;
                        incBook.CommandText = "UPDATE Books SET AvailableCopies = MIN(TotalCopies, AvailableCopies + 1) WHERE Id = @BookId;";
                        incBook.Parameters.AddWithValue("@BookId", bookId);
                        incBook.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return (true, "Book returned successfully!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return (false, "Error processing return: " + ex.Message);
                }
            }
        }

        public static void UpdateOverdueStatuses()
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Transactions 
                        SET Status = 'Overdue'
                        WHERE Status = 'Borrowed' AND datetime(DueDate) < datetime('now');";
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
               
            }
        }

        public static List<TransactionDetailView> GetTransactions(string search = "", string status = "All", DateTime? fromDate = null, DateTime? toDate = null, int? memberId = null)
        {
            var list = new List<TransactionDetailView>();
            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                var sb = new StringBuilder(@"
                    SELECT t.Id, t.TransactionCode, b.Title, b.ISBN, m.FullName, m.MemberCode, 
                           t.IssueDate, t.DueDate, t.ReturnDate, t.Status, u.FullName
                    FROM Transactions t
                    JOIN Books b ON t.BookId = b.Id
                    JOIN Members m ON t.MemberId = m.Id
                    LEFT JOIN Users u ON t.IssuedByUserId = u.Id
                    WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(search))
                {
                    sb.Append(" AND (LOWER(t.TransactionCode) LIKE @Search OR LOWER(b.Title) LIKE @Search OR LOWER(m.FullName) LIKE @Search OR LOWER(m.MemberCode) LIKE @Search) ");
                    cmd.Parameters.AddWithValue("@Search", $"%{search.Trim().ToLower()}%");
                }

                if (!string.IsNullOrWhiteSpace(status) && status != "All" && status != "All Statuses")
                {
                    sb.Append(" AND t.Status = @Status ");
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                if (fromDate.HasValue)
                {
                    sb.Append(" AND date(t.IssueDate) >= date(@FromDate) ");
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Value.ToString("yyyy-MM-dd"));
                }

                if (toDate.HasValue)
                {
                    sb.Append(" AND date(t.IssueDate) <= date(@ToDate) ");
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Value.ToString("yyyy-MM-dd"));
                }

                if (memberId.HasValue)
                {
                    sb.Append(" AND t.MemberId = @MemberId ");
                    cmd.Parameters.AddWithValue("@MemberId", memberId.Value);
                }

                sb.Append(" ORDER BY t.Id DESC;");
                cmd.CommandText = sb.ToString();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TransactionDetailView
                        {
                            Id = reader.GetInt32(0),
                            TransactionCode = reader.GetString(1),
                            BookTitle = reader.GetString(2),
                            ISBN = reader.GetString(3),
                            MemberName = reader.GetString(4),
                            MemberCode = reader.GetString(5),
                            IssueDate = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            DueDate = reader.IsDBNull(7) ? "" : reader.GetString(7),
                            ReturnDate = reader.IsDBNull(8) ? "Pending" : reader.GetString(8),
                            Status = reader.GetString(9),
                            IssuerName = reader.IsDBNull(10) ? "System" : reader.GetString(10)
                        });
                    }
                }
            }
            return list;
        }

        

        public static DashboardStats GetDashboardStats()
        {
            UpdateOverdueStatuses();
            var stats = new DashboardStats();

            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT 
                        (SELECT COALESCE(SUM(TotalCopies), 0) FROM Books) AS TotalBooks,
                        (SELECT COALESCE(SUM(AvailableCopies), 0) FROM Books) AS AvailableBooks,
                        (SELECT COUNT(*) FROM Transactions WHERE Status = 'Borrowed') AS BorrowedBooks,
                        (SELECT COUNT(*) FROM Transactions WHERE Status = 'Overdue') AS OverdueBooks,
                        (SELECT COUNT(*) FROM Members WHERE Status = 'Active') AS TotalMembers,
                        (SELECT COUNT(*) FROM Users WHERE IsActive = 1) AS TotalUsers,
                        (SELECT COUNT(*) FROM Transactions WHERE Status = 'Returned') AS TotalReturned;";

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stats.TotalBooks = reader.GetInt32(0);
                        stats.AvailableBooks = reader.GetInt32(1);
                        stats.BorrowedBooks = reader.GetInt32(2);
                        stats.OverdueBooks = reader.GetInt32(3);
                        stats.TotalMembers = reader.GetInt32(4);
                        stats.TotalUsers = reader.GetInt32(5);
                        stats.TotalReturned = reader.GetInt32(6);
                    }
                }
            }
            return stats;
        }

        public static UserDashboardStats GetUserDashboardStats(int memberId)
        {
            UpdateOverdueStatuses();
            var stats = new UserDashboardStats();

            using (var conn = GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Transactions WHERE MemberId = @MemberId AND Status = 'Borrowed') AS MyBorrowed,
                        (SELECT COUNT(*) FROM Transactions WHERE MemberId = @MemberId AND Status = 'Overdue') AS MyOverdue,
                        (SELECT COUNT(*) FROM Transactions WHERE MemberId = @MemberId) AS MyHistory,
                        (SELECT COALESCE(SUM(AvailableCopies), 0) FROM Books) AS CatalogAvailable;";
                cmd.Parameters.AddWithValue("@MemberId", memberId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        stats.MyBorrowedBooks = reader.GetInt32(0);
                        stats.MyOverdueBooks = reader.GetInt32(1);
                        stats.MyTotalHistory = reader.GetInt32(2);
                        stats.TotalCatalogAvailable = reader.GetInt32(3);
                    }
                }
            }
            return stats;
        }
    }
}

