namespace WebApp.Models
{
    public class Block
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public int Block1 { get; set; }
        public int Block2 { get; set; }
        public int Block3 { get; set; }
        public int Block4 { get; set; }
        public int Block5 { get; set; }
        public int Block6 { get; set; }
        public int Block7 { get; set; }
        public int Block8 { get; set; }

        public Block(DateTime Date, int block, int ticket_id)
        {
            date = Date;

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
    }
}
