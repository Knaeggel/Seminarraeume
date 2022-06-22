namespace WebApp.Models
{
    public class TicketShow
    {
        //is a class for better transport the data to the view
        public string sDate { get; set; }
        public string Room { get; set; }
        public string times { get; set; }
        public bool overbooked { get; set; }
        public int id { get; set; }

        public TicketShow(string sDate, string room, int block, bool Overbooked, int id)
        {
            this.sDate = sDate;
            Room = room;
            this.times = GetTimes(block);
            overbooked = Overbooked;
            this.id = id;
        }

        public TicketShow(string sDate, string room, string time, int id)
        {
            this.sDate = sDate;
            this.Room = room;
            this.times = time;
            this.id = id;
        }

        public TicketShow()
        {

        }

        public static string GetTimes(int block)
        {
            string ret = "";

            switch (block)
            {
                case 1:
                    ret = "08:00 - 09:30";
                    break;
                case 2:
                    ret = "09:45 - 11:15";
                    break;
                case 3:
                    ret = "11:35 - 13:05";
                    break;
                case 4:
                    ret = "14:00 - 15:30";
                    break;
                case 5:
                    ret = "15:45 - 17:15";
                    break;
                case 6:
                    ret = "17:30 - 19:00";
                    break;
                case 7:
                    ret = "19:15 - 20:45";
                    break;
                case 8:
                    ret = "21:00 - 22:30";
                    break;

                default:
                    break;
            }

            return ret;
        }

        public string getClass()
        {
            string ret = "";

            if (overbooked)
            {
                ret = "overBooked";
            }

            return ret;
        }
        public int getBlock()
        {
            var ret = 0;
            switch (times)
            {
                case "08:00 - 09:30":
                    ret = 1;
                    break;
                case "09:45 - 11:15":
                    ret = 2;
                    break;
                case "11:35 - 13:05":
                    ret = 3;
                    break;
                case "14:00 - 15:30":
                    ret = 4;
                    break;
                case "15:45 - 17:15":
                    ret = 5;
                    break;
                case "17:30 - 19:00":
                    ret = 6;
                    break;
                case "19:15 - 20:45":
                    ret = 7;
                    break;
                case "21:00 - 22:30":
                    ret = 8;
                    break;

                default:
                    break;
            }

            return ret;
        }

        public DateTime getDate()
        {
            return DateTime.Parse(sDate);
        }
    }
}
