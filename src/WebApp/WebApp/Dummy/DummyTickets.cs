using Microsoft.AspNetCore.Identity;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Dummy
{
    public class DummyTickets
    {
        public DummyTickets(ApplicationDbContext dbSet, UserManager<IdentityUser> userMgr)
        {
            FillDummy(dbSet, userMgr).Wait();
        }

        public async Task FillDummy(ApplicationDbContext dbSet, UserManager<IdentityUser> userMgr)
        {
            var random = new Random();

            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 50; i++)
                {

                    var user = await userMgr.FindByNameAsync("User" + random.Next(1, 70) + "@proOne.de");

                    if (user != null)
                    {
                        var newDate = DateTime.Now;
                        newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
                        newDate = newDate.AddDays(j);

                        var newTicket = new Ticket(random.Next(1, 56), user.UserName, newDate, random.Next(1, 8));

                        var found = false;
                        foreach (var item in dbSet.Tickets.ToList())
                        {
                            if (newTicket.compare(item))
                            {
                                found = true;
                            }
                        }

                        if (!found)
                        {
                            dbSet.Tickets.Add(newTicket);
                            dbSet.SaveChanges();

                            foreach (var item in dbSet.Ticktes.ToList())
                            {
                                if (item.compare(newTicket))
                                {
                                    Ticket.EditCreateDay(dbSet, item);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
