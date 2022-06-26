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

                for (int j = 0; j < 14; j++)
                {
                    for (int i = 0; i < 70; i++)
                    {

                        var user = await userMgr.FindByNameAsync("User" + random.Next(1, 50) + "@proOne.de");

                        if (user != null)
                        {
                            var newDate = DateTime.Now;
                            newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
                            newDate = newDate.AddDays(j);

                            var newTicket = new Ticket(random.Next(1, 57), user.UserName, newDate, random.Next(1, 9));

                            var found = false;
                            foreach (var item in dbSet.Tickets.ToList())
                            {
                                if (newTicket.same(item))
                                {
                                    found = true;
                                    break;
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
                    

                    for (int i = 0; i < 15; i++)
                    {
                        var user = await userMgr.FindByNameAsync("Prof" + random.Next(1, 11) + "@proOne.de");

                        if (user != null)
                        {
                            var newDate = DateTime.Now;
                            newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
                            newDate = newDate.AddDays(j);

                            var newTicket = new Ticket(random.Next(1, 56), user.UserName, newDate, random.Next(1, 9));

                            var found = false;
                            foreach (var item in dbSet.Tickets.ToList())
                            {
                                if (newTicket.same(item))
                                {
                                    found = true;
                                    break;
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

                    for (int i = 0; i < 20; i++)
                    {
                        var user = await userMgr.FindByNameAsync("Tutor" + random.Next(1, 21) + "@proOne.de");

                        if (user != null)
                        {
                            var newDate = DateTime.Now;
                            newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
                            newDate = newDate.AddDays(j);

                            var newTicket = new Ticket(random.Next(1, 56), user.UserName, newDate, random.Next(1, 9));

                            var found = false;
                            foreach (var item in dbSet.Tickets.ToList())
                            {
                                if (newTicket.same(item))
                                {
                                    found = true;
                                    break;
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
}
