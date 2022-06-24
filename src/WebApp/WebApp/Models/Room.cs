namespace WebApp.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int RoomSize { get; set; }
        public string? RoomName { get; set; }
        public string? KindOfRoom { get; set; }

        //useless
        public int BlockID { get; set; }
        //useless
        public bool Status { get; set; }

        public bool validateRoom(SearchValues paras)
        {
            var ret = true;

            if (paras.building != "all" && paras.building.ElementAt(0) != this.RoomName.ElementAt(0))
            {
                ret = false;
            }

            if (paras.roomnumber != this.RoomName.Substring(1, paras.roomnumber.ToString().Length))
            {
                ret = false;
            }

            if (this.RoomSize < paras.room.RoomSize)
            {
                ret = false;
            }

            if (paras.room.KindOfRoom != "All" && this.KindOfRoom != paras.room.KindOfRoom)
            {
                ret = false;
            }


            return ret;
        }
    }
}
