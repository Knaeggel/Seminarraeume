using WebApp.Data;
using WebApp.Models;

namespace WebApp.Dummy
{
    public class DummyTickets
    {
        public DummyTickets(ApplicationDbContext dbSet)
        {
            FillDummy(dbSet);
        }

        public void FillDummy(ApplicationDbContext dbSet)
        {
            var tickets = dbSet.Ticktes.ToList();

            //create Tickets loop
            for (int i = 0; i < 20; i++)
            {
                //proof, that this ticket doesnt exist
                bool found = false;
                var newTicket = new Ticket(i, i, (i + 1) % 9);

                foreach (var item in tickets)
                {
                    if (newTicket.block == item.block && newTicket.room == item.room)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    //add new Ticket
                    dbSet.Ticktes.Add(newTicket);

                    //Weil wir die ID sonst nicht haben müssen wird das Elem nochmal aus der DB holen
                    foreach (var item in dbSet.Ticktes.ToList())
                    {
                        if (item.compare(newTicket))
                        {
                            newTicket = item;
                        }
                    }

                    Room room = null;

                    // search for the room
                    foreach (var item in dbSet.Rooms.ToList())
                    {
                        if (item.Id == i)
                        {
                            room = item;
                        }
                    }

                    if (room != null)
                    {
                        Block block = null;

                        //seach for the block
                        foreach (var item in dbSet.Blocks.ToList())
                        {
                            if (room.BlockID == item.ID)
                            {
                                block = item;
                            }
                        }

                        if (block != null)
                        {
                            //add ticket id to the right block
                            block.Block1 = newTicket.id;
                        }
                        else
                        {
                            dbSet.Blocks.Add(new Block(new DateTime(2022, 10, 15), 1, newTicket.id));
                        }

                    }
                }
            }
        }
    }
}
