namespace WebApp.Models
{
    public class BookingResult : TicketShow
    {

        public bool suc { get; set; }
        public BookingResult(string sDate, string room, int block, bool success) : base(sDate, room, block, false, 0)
        {
            suc = success;
        }

        
        public string getBookingResultClass()
        {
            string ret = "";

            if (!suc)
            {
                ret = "overBooked";
            }

            return ret;
        }
    }
}