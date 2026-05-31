namespace EverpineHotelManagement.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = ""; 
        public int GuestId { get; set; }
        public string GuestFullName { get; set; } = ""; 
        public int UserId { get; set; }
        public string UserFullName { get; set; } = ""; 
        public string CheckInDate { get; set; } = "";
        public string CheckOutDate { get; set; } = "";
        public double TotalPrice { get; set; }
        public string Status { get; set; } = ""; 
    }
}