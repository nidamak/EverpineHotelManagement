using System;
using System.Collections.Generic;
using EverpineHotelManagement.Models;

namespace EverpineHotelManagement.Data
{
    internal class BookingRepository
    {
        public List<Booking> GetAllBookings()
        {
            var list = new List<Booking>();
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    SELECT b.Id, b.RoomId, r.RoomNumber, b.GuestId, g.FullName, b.UserId, u.FullName, 
                           b.CheckInDate, b.CheckOutDate, b.TotalPrice, b.Status
                    FROM Bookings b
                    JOIN Rooms r ON b.RoomId = r.Id
                    JOIN Guests g ON b.GuestId = g.Id
                    JOIN Users u ON b.UserId = u.Id";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Booking
                        {
                            Id = reader.GetInt32(0),
                            RoomId = reader.GetInt32(1),        
                            RoomNumber = reader.GetString(2),
                            GuestId = reader.GetInt32(3),     
                            GuestFullName = reader.GetString(4),
                            UserId = reader.GetInt32(5),     
                            UserFullName = reader.GetString(6),
                            CheckInDate = reader.GetString(7),
                            CheckOutDate = reader.GetString(8),
                            TotalPrice = reader.GetDouble(9),
                            Status = reader.GetString(10)
                        });
                    }
                }
            }
            return list;
        }

        public void AddBooking(int roomId, int guestId, int userId, string checkIn, string checkOut, double price, string status)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO Bookings (RoomId, GuestId, UserId, CheckInDate, CheckOutDate, TotalPrice, Status) 
                                   VALUES ($roomId, $guestId, $userId, $checkIn, $checkOut, $price, $status)";

                cmd.Parameters.AddWithValue("$roomId", roomId);
                cmd.Parameters.AddWithValue("$guestId", guestId);
                cmd.Parameters.AddWithValue("$userId", userId);
                cmd.Parameters.AddWithValue("$checkIn", checkIn);
                cmd.Parameters.AddWithValue("$checkOut", checkOut);
                cmd.Parameters.AddWithValue("$price", price);
                cmd.Parameters.AddWithValue("$status", status);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBooking(int id)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Bookings WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBooking(int id, int roomId, int guestId, string checkIn, string checkOut, double price, string status)
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"UPDATE Bookings SET 
                            RoomId = $roomId, 
                            GuestId = $guestId, 
                            CheckInDate = $checkIn, 
                            CheckOutDate = $checkOut, 
                            TotalPrice = $price, 
                            Status = $status 
                            WHERE Id = $id";

                cmd.Parameters.AddWithValue("$id", id);
                cmd.Parameters.AddWithValue("$roomId", roomId);
                cmd.Parameters.AddWithValue("$guestId", guestId);
                cmd.Parameters.AddWithValue("$checkIn", checkIn);
                cmd.Parameters.AddWithValue("$checkOut", checkOut);
                cmd.Parameters.AddWithValue("$price", price);
                cmd.Parameters.AddWithValue("$status", status);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
