using EverpineHotelManagement.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace EverpineHotelManagement.Data
{
    public class GuestRepository
    {
        public List<Guest> GetAllGuests()
        {
            var list = new List<Guest>();
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, FullName, Passport, Phone FROM Guests";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Guest
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Passport = reader.GetString(2),
                            Phone = reader.GetString(3)
                        });
                    }
                }
            }
            return list;
        }

        public void AddGuest(string fullName, string passport, string phone)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Guests (FullName, Passport, Phone) VALUES ($name, $passport, $phone)";
                cmd.Parameters.AddWithValue("$name", fullName);
                cmd.Parameters.AddWithValue("$passport", passport);
                cmd.Parameters.AddWithValue("$phone", phone);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateGuest(int id, string fullName, string passport, string phone)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Guests SET FullName=$name, Passport=$passport, Phone=$phone WHERE Id=$id";
                cmd.Parameters.AddWithValue("$name", fullName);
                cmd.Parameters.AddWithValue("$passport", passport);
                cmd.Parameters.AddWithValue("$phone", phone);
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteGuest(int id)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Guests WHERE Id = $id";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}