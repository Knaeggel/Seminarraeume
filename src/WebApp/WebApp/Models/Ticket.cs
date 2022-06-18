using WebApp.Data;

namespace WebApp.Models
{


    public class Ticket
    {
        public int id { get; set; }
        public int room { get; set; }
        public String user { get; set; }
        public DateTime date { get; set; }
        public int block { get; set; }
        public bool overbooked { get; set; }

        public Ticket(int Room, String User, DateTime Date,int Block)
        {
            room = Room;
            user = User;
            block = Block;
            date = Date;
        }

        public Ticket()
        {
            overbooked = false;
        }

        public bool compare(Ticket othertTicket)
        {
            var ret = false;

            if (this.block == othertTicket.block && this.user.Equals(othertTicket.user) && this.room == othertTicket.room && this.date.ToString("dd.MM.yy").Equals(othertTicket.date.ToString("dd.MM.yy")))
            {
                ret = true;
            }

            return ret;
        }

        public bool same(Ticket otherTicket)
        {
            var ret = false;

            if (this.block == otherTicket.block && this.room == otherTicket.room && this.date.ToString("dd.MM.yy").Equals(otherTicket.date.ToString("dd.MM.yy")))
            {
                ret = true;
            }

            return ret;
        }

        public static void EditCreateDay(ApplicationDbContext dbSet, Ticket ticket)
        {
            Day day = null;

            foreach (var item in dbSet.Days.ToList())
            {
                if (item.date.Equals(ticket.date) && item.Room == ticket.room)
                {
                    day = item;
                    break;
                }
            }

            if (day == null)
            {
                day = new Day(ticket.date, ticket.block, ticket.room, ticket.id);
                dbSet.Days.Add(day);
            }
            else
            {
                day.setBlock(ticket.block, ticket.id);
                dbSet.Update(day);
            }
            dbSet.SaveChanges();
        }

        public DateTime getTicketTime()
        {
            DateTime time;
            switch(block)
            {
                case 1: 
                    time = date.AddMinutes(570);
                    break;
                case 2:
                    time = date.AddMinutes(675);
                    break;
                case 3:
                    time = date.AddMinutes(785);
                    break;
                case 4:
                    time = date.AddMinutes(930);
                    break;
                case 5:
                    time = date.AddMinutes(1035);
                    break;
                case 6:
                    time = date.AddMinutes(1140);
                    break;
                case 7:
                    time = date.AddMinutes(1245);
                    break;
                case 8:
                    time = date.AddMinutes(1350);
                    break;
                default:
                    time = date.AddMinutes(0);
                    break;
            }
            return time;
        }
        
    }
}
