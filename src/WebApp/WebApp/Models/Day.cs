namespace WebApp.Models
{
    public class Day
    {
        public int ID { get; set; }
        public int Room { get; set; }
        public DateTime date { get; set; }
        public int Block1 { get; set; }
        public int Block2 { get; set; }
        public int Block3 { get; set; }
        public int Block4 { get; set; }
        public int Block5 { get; set; }
        public int Block6 { get; set; }
        public int Block7 { get; set; }
        public int Block8 { get; set; }

        public Day(DateTime Date, int block, int room, int ticket_id)
        {
            date = Date;
            Room = room;

            setBlock(block, ticket_id);
        }

        public Day(DateTime Date)
        {
            date = Date;
        }

        public Day()
        {

        }

        //for easyer set a bolock with the ticket id
        public void setBlock(int block, int ticket_id)
        {
            switch (block)
            {
                case 1:
                    Block1 = ticket_id; break;
                case 2:
                    Block2 = ticket_id; break;
                case 3:
                    Block3 = ticket_id; break;
                case 4:
                    Block4 = ticket_id; break;
                case 5:
                    Block5 = ticket_id; break;
                case 6:
                    Block6 = ticket_id; break;
                case 7:
                    Block7 = ticket_id; break;
                case 8:
                    Block8 = ticket_id; break;
            }
        }

        public int getTicketId(int block)
        {
            int id = 0;

            switch (block)
            {
                case 1:
                    id = Block1; break;
                case 2:
                    id = Block2; break;
                case 3:
                    id = Block3; break;
                case 4:
                    id = Block4; break;
                case 5:
                    id = Block5; break;
                case 6:
                    id = Block6; break;
                case 7:
                    id = Block7; break;
                case 8:
                    id = Block8; break;
            }
            return id;
        }

        public int getTicketIdByDate(DateTime date)
        {
            int id = 0;

            switch (date.ToString("HH:mm"))
            {
                case "08:00":
                    id = Block1; break;
                case "09:45":
                    id = Block2; break;
                case "11:35":
                    id = Block3; break;
                case "14:00":
                    id = Block4; break;
                case "15:45":
                    id = Block5; break;
                case "17:30":
                    id = Block6; break;
                case "19:15":
                    id = Block7; break;
                case "21:00":
                    id = Block8; break;
            }

            return id;
        }
    }
}
