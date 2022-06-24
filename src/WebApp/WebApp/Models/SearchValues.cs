namespace WebApp.Models
{
    public class SearchValues
    {
        public Room room { get; set; }
        public Ticket ticket { get; set; }

        private string building;
        public string Building
        {
            get { return building; }
            set 
            {
                CreatRoomName(roomnumber, value);
                building = value; 
            }
        }

        private int roomnumber;
        public int Roomnumber
        {
            get { return roomnumber; }
            set 
            {
                CreatRoomName(value, building);
                roomnumber = value; 
            }
        }

        public SearchValues()
        {
            room = new Room();
        }

        private void CreatRoomName(int Roomnumber, string Building)
        {
            if (building != null)
            {
                room.RoomName = Building + Roomnumber;
            }
            else
            {
                room.RoomName = Roomnumber.ToString();
            }
        }

    }
}
