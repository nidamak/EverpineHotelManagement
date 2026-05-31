namespace EverpineHotelManagement.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Passport { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}