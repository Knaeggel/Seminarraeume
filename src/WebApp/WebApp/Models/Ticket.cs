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

    }
}
