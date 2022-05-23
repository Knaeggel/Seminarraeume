namespace WebApp.Models
{


    public class Ticket
    {
        public Ticket(int Room, int User, int Block)
        {
            room = Room;
            user = User;
            block = Block;
        }

        public Ticket()
        {

        }


        public int id { get; set; }

        public int room { get; set; }
        public int user { get; set; }
        public DateTime date { get; set; }
        public int block { get; set; }

        public bool compare(Ticket othertTicket)
        {
            var ret = false;

            if (this.block == othertTicket.block && this.user == othertTicket.user && this.room == othertTicket.room && this.date == othertTicket.date)
            {
                ret = true;
            }

            return ret;
        }

    }
}
