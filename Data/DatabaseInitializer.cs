using System;
using Microsoft.Data.Sqlite;

namespace EverpineHotelManagement.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();

                string createRolesTable = @"
                    CREATE TABLE IF NOT EXISTS Roles (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                    );";

                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoleId INTEGER NOT NULL,
                        Login TEXT NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        PasswordSalt TEXT NOT NULL,
                        FullName TEXT NOT NULL,
                        IsActive INTEGER NOT NULL DEFAULT 1,
                        CreatedAt TEXT NOT NULL,
                        FOREIGN KEY (RoleId) REFERENCES Roles(Id)
                    );";

                string createLoginAttemptsTable = @"
                    CREATE TABLE IF NOT EXISTS LoginAttempts (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserLogin TEXT NOT NULL,
                        IsSuccess INTEGER NOT NULL,
                        Message TEXT NOT NULL,
                        CreatedAt TEXT NOT NULL
                    );";

                string createRoomsTable = @"
                    CREATE TABLE IF NOT EXISTS Rooms (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomNumber TEXT NOT NULL UNIQUE,
                        Type TEXT NOT NULL,
                        Price REAL NOT NULL,
                        IsAvailable INTEGER NOT NULL DEFAULT 1
                    );";

                string createGuestsTable = @"
                    CREATE TABLE IF NOT EXISTS Guests (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        Passport TEXT NOT NULL,
                        Phone TEXT
                    );";

                string createBookingsTable = @"
                    CREATE TABLE IF NOT EXISTS Bookings (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomId INTEGER NOT NULL,
                        GuestId INTEGER NOT NULL,
                        UserId INTEGER NOT NULL,
                        CheckInDate TEXT NOT NULL,
                        CheckOutDate TEXT NOT NULL,
                        TotalPrice REAL NOT NULL,
                        Status TEXT NOT NULL,
                        FOREIGN KEY (RoomId) REFERENCES Rooms(Id),
                        FOREIGN KEY (GuestId) REFERENCES Guests(Id),
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                    );";

                Execute(connection, createRolesTable);
                Execute(connection, createUsersTable);
                Execute(connection, createLoginAttemptsTable);
                Execute(connection, createRoomsTable);
                Execute(connection, createGuestsTable);
                Execute(connection, createBookingsTable);

                using (var checkCmd = connection.CreateCommand())
                { 
                    checkCmd.CommandText = "SELECT COUNT(*) FROM Roles;";
                    long rolesCount = (long)checkCmd.ExecuteScalar();
                    if (rolesCount == 0)
                    {
                        Execute(connection, "INSERT INTO Roles (Id, Name) VALUES (1, 'admin'), (2, 'operator'), (3, 'user');");
                    }
                     
                    checkCmd.CommandText = "SELECT COUNT(*) FROM Users;";
                    long usersCount = (long)checkCmd.ExecuteScalar();
                    if (usersCount == 0)
                    {
                        var usersToCreate = new[]
                        {
        new { Login = "admin", Pass = "admin123", Name = "Главный Администратор", RoleId = 1 },
        new { Login = "operator", Pass = "oper123", Name = "Портье", RoleId = 2 },
        new { Login = "user", Pass = "user123", Name = "Стажер", RoleId = 3 }
    };

                        foreach (var u in usersToCreate)
                        {
                            string salt = EverpineHotelManagement.Services.PasswordHasher.GenerateSalt();
                            string hash = EverpineHotelManagement.Services.PasswordHasher.HashPassword(u.Pass, salt);
                            string createdAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            using (var insertUserCmd = connection.CreateCommand())
                            {
                                insertUserCmd.CommandText = @"
                                    INSERT INTO Users (RoleId, Login, PasswordHash, PasswordSalt, FullName, IsActive, CreatedAt)
                                    VALUES (@RoleId, @Login, @Hash, @Salt, @FullName, 1, @CreatedAt);";

                                insertUserCmd.Parameters.AddWithValue("@RoleId", u.RoleId);
                                insertUserCmd.Parameters.AddWithValue("@Login", u.Login);
                                insertUserCmd.Parameters.AddWithValue("@Hash", hash);
                                insertUserCmd.Parameters.AddWithValue("@Salt", salt);
                                insertUserCmd.Parameters.AddWithValue("@FullName", u.Name);
                                insertUserCmd.Parameters.AddWithValue("@CreatedAt", createdAt);

                                insertUserCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        private static void Execute(SqliteConnection connection, string sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}