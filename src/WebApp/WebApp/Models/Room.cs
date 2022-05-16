namespace WebApp.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int RoomSize { get; set; }
        public string? RoomName { get; set; }
        public string? KindOfRoom { get; set; }
        public int Time { get; set; }
        public bool Status { get; set; }
    }
}
