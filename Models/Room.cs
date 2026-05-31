namespace EverpineHotelManagement.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = "";
        public string Type { get; set; } = ""; 
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}