﻿namespace WebApp.Models
{


    public class Ticket
    {
        public int id { get; set; }
        public int room { get; set; }
        public String user { get; set; }
        public DateTime date { get; set; }
        public int block { get; set; }

        public Ticket(int Room, String User, DateTime Date,int Block)
        {
            room = Room;
            user = User;
            block = Block;
            date = Date;
        }

        public Ticket()
        {

        }

        public bool compare(Ticket othertTicket)
        {
            var ret = false;

            if (this.block == othertTicket.block && this.user.Equals(othertTicket.user) && this.room == othertTicket.room && this.date.Equals(othertTicket.date))
            {
                ret = true;
            }

            return ret;
        }

    }
}
