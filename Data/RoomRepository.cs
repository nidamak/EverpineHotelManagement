using EverpineHotelManagement.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace EverpineHotelManagement.Data
{
    public class RoomRepository
    {
        public List<Room> GetAvailableRooms()
        {
            var list = new List<Room>();
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, RoomNumber, Type, Price, IsAvailable FROM Rooms WHERE IsAvailable = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Room
                        {
                            Id = reader.GetInt32(0),
                            RoomNumber = reader.GetString(1),
                            Type = reader.GetString(2),
                            Price = reader.GetDouble(3),
                            IsAvailable = reader.GetInt32(4) == 1
                        });
                    }
                }
            }
            return list;
        }

        public void AddRoom(string number, string type, double price, bool available)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Rooms (RoomNumber, Type, Price, IsAvailable) VALUES ($num, $type, $price, $avail)";
                cmd.Parameters.AddWithValue("$num", number);
                cmd.Parameters.AddWithValue("$type", type);
                cmd.Parameters.AddWithValue("$price", price);
                cmd.Parameters.AddWithValue("$avail", available ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateRoom(int id, string number, string type, double price, bool available)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Rooms SET RoomNumber=$num, Type=$type, Price=$price, IsAvailable=$avail WHERE Id=$id";
                cmd.Parameters.AddWithValue("$num", number);
                cmd.Parameters.AddWithValue("$type", type);
                cmd.Parameters.AddWithValue("$price", price);
                cmd.Parameters.AddWithValue("$avail", available ? 1 : 0);
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRoom(int id)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Rooms WHERE Id = $id";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
        }

        public void SetRoomAvailability(int roomId, bool isAvailable)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Rooms SET IsAvailable = $avail WHERE Id = $id";

                cmd.Parameters.AddWithValue("$avail", isAvailable ? 1 : 0);
                cmd.Parameters.AddWithValue("$id", roomId);

                cmd.ExecuteNonQuery();
            }
        }

    }
}