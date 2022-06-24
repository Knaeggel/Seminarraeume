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

        public bool validateRoom(Room Paras)
        {
            var ret = true;

            if (this.RoomName != Paras.RoomName && Paras.RoomName.Length > 0)
            {
                if (!Paras.RoomName.Contains("All"))
                {
                    char building = Paras.RoomName.ElementAt(0);
                    char thisbuilding = RoomName.ElementAt(0);
                    if (thisbuilding != building)
                    {
                        ret = false;
                    }


                    string Number = Paras.RoomName.Substring(1, Paras.RoomName.Length - 1);
                    string thisNumber = RoomName.Substring(1, Paras.RoomName.Length - 1);

                    if (thisNumber != Number)
                    {
                        ret = false;
                    }
                }
                else
                {
                    string Number = Paras.RoomName.Substring(3, Paras.RoomName.Length - 3);
                    string thisNumber = RoomName.Substring(1, Paras.RoomName.Length - 3);

                    if (thisNumber != Number)
                    {
                        ret = false;
                    }
                }
            }

            if (this.RoomSize < Paras.RoomSize)
            {
                ret = false;
            }

            if (Paras.KindOfRoom != "All" && this.KindOfRoom != Paras.KindOfRoom)
            {
                ret = false;
            }


            return ret;
        }
    }
}
