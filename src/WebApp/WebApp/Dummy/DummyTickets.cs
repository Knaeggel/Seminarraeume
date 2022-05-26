﻿using Microsoft.AspNetCore.Identity;
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

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 30; i++)
                {

                    var user = await userMgr.FindByNameAsync("User" + random.Next(1, 70) + "@proOne.de");

                    if (user != null)
                    {
                        var newTicket = new Ticket(random.Next(1, 50), user.UserName, new DateTime(2022, 7, 27 + j), random.Next(1, 8));

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
                        }
                    }
                }
            }
        }
    }
}
