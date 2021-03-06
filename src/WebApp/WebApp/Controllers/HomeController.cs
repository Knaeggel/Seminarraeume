using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Dummy;
using WebApp.Models;
using WebApp.Data;
using WebApp.Feature;
using WebApp.Manager;

namespace WebApp.Controllers
{

    //Jede HTTP anfrage wird hier entgegen genommen und bearbeitet

    public class HomeController : Controller
    {
        private static bool first = true;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private Room selectedRoom;
        UserManager<IdentityUser> userManager;

        public static SemaphoreSlim sem = new SemaphoreSlim(1);

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMgr, ApplicationDbContext con)
        {
            _logger = logger;
            _context = con;
            userManager = userMgr;

            if (first == true)
            {
                //erstellen der dummy Daten

                var dummyRoles = new DummyRoles(roleMgr);
                var dummyUsers = new DummyUsers(userMgr);
                var DummyRooms = new DummyRooms(con);
                //   var dummyTickets = new DummyTickets(con, userMgr);

            }


            first = false;
        }

        //shows the booked tickets
        [Authorize]
        public IActionResult booked()
        {
            //find the booked tickets and slecet them in the list ticktes
            List<TicketShow> tickets = new List<TicketShow>();
            foreach (var item in _context.Tickets.ToList())
            {
                if (item.user.Equals(User.Identity.Name) && (DateTime.Now <= item.getTicketTime()))
                {
                    foreach (var elem in _context.Rooms.ToList())
                    {
                        if (elem.Id == item.room)
                        {
                            tickets.Add(new TicketShow(item.date.ToString("dd.MM.yyyy"), elem.RoomName, item.block, item.overbooked, item.id));
                            break;
                        }
                    }
                }
            }

            //you can unpack the ViewBag in the View
            ViewBag.Tickets = tickets;
            return View();
        }

        //shows history page
        [Authorize]
        public IActionResult history()
        {
            //find the booked tickets and slecet them in the list ticktes
            List<TicketShow> tickets = new List<TicketShow>();
            foreach (var item in _context.Tickets.ToList())
            {

                if ((item.user.Equals(User.Identity.Name)) && (DateTime.Now > item.getTicketTime()))
                {
                    foreach (var elem in _context.Rooms.ToList())
                    {
                        if (elem.Id == item.room)
                        {
                            tickets.Add(new TicketShow(item.date.ToString("dd.MM.yyyy"), elem.RoomName, item.block, item.overbooked, item.id));
                            break;
                        }
                    }
                }
            }

            //you can unpack the ViewBag in the View
            ViewBag.Tickets = tickets;
            return View();
        }

        //the room search with view
        public IActionResult räume()
        {
            if (User.Identity != null && User.Identity.Name != null)
            {
                addDefaultRole(User.Identity.Name).Wait();
            }

            //select all rooms
            ViewBag.Rooms = _context.Rooms.ToList();

            return View();
        }

        //the Room with boocked days/blocks
        public async Task<IActionResult> RoomView(string name)
        {
            var today = new DateTime();
            today = DateTime.Now;
            List<Day> days = new List<Day>();
            IdentityUser user = null;

            if (name != null)
            {
                if (User.Identity != null && User.Identity.Name != null)
                {
                    user = await userManager.FindByNameAsync(User.Identity.Name);
                }


                //fiend the room
                foreach (var item in _context.Rooms.ToList())
                {
                    if (item.RoomName == name)
                    {
                        selectedRoom = item;
                        break;
                    }
                }

                //get aktuell Date
                var tempDate = DateTime.Now;

                //create a list with 14 days
                for (int i = 0; i < 14; i++)
                {
                    var found = false;
                    foreach (var item in _context.Days.ToList())
                    {
                        if (item.Room == selectedRoom.Id && item.date.ToString("dd.MM.yyyy").Equals(tempDate.ToString("dd.MM.yyyy")))
                        {
                            days.Add(item);
                            found = true;
                            break;
                        }
                    }

                    //when the day doesnt exist we're creating a new with only the daystamp
                    if (!found)
                    {
                        days.Add(new Day(tempDate));
                    }

                    tempDate = tempDate.AddDays(1);
                }
            }


            List<EasyBookingCreator[]> betterDays = await EasyBookingCreator.CreateEasyBookingList(days, _context.Tickets.ToList(), userManager);

            UserRoles role = UserRoles.empty;
            if (user != null)
            {
                role = await RoleManagerP.getRole(userManager, user);
            }

            foreach (var item in betterDays)
            {
                for (int i = 0; i < 8; i++)
                {
                    item[i].bookable = "false";

                    if (user != null)
                    {
                        //increase search speed
                        item[i].Overbookable(role);
                    }
                }
            }

            //bring them to the front end
            //ViewBag.date = today;
            ViewBag.Days = betterDays;
            ViewBag.Room = selectedRoom;



            return PartialView("RoomView");
        }

        [HttpPost]
        public IActionResult CreatTicketsAsync(BookingClass selected)
        {
            sem.Wait();
            //the method called when you click Save (speichern)
            List<Ticket> newTickets = new List<Ticket>();
            Ticket existingTicket = null;

            for (int i = 0; i < selected.days.Length; i++)
            {
                for (int j = 0; j < selected.days[i].blocks.Length; j++)
                {
                    if (selected.days[i].blocks[j])
                    {
                        foreach (var item in _context.Rooms.ToList())
                        {
                            if (item.RoomName == selected.room.RoomName)
                            {
                                newTickets.Add(new Ticket(item.Id, User.Identity.Name, selected.days[i].date, j + 1));
                                break;
                            }
                        }
                    }
                }
            }

            List<BookingResult> bookedList = new List<BookingResult>();

            foreach (var newTicket in newTickets)
            {
                bool foundTicket = false;
                foreach (var oldticket in _context.Ticktes.ToList())
                {
                    if (newTicket.same(oldticket))
                    {
                        existingTicket = oldticket;
                        foundTicket = true;
                        break;
                    }
                }

                if (!foundTicket)
                {
                    _context.Tickets.Add(newTicket);
                    _context.SaveChanges();
                    Ticket ticket = null;

                    foreach (var item in _context.Tickets.ToList())
                    {
                        if (item.compare(newTicket))
                        {
                            ticket = item;
                            break;
                        }
                    }

                    if (ticket != null)
                    {
                        Ticket.EditCreateDay(_context, ticket);
                        bookedList.Add(new BookingResult(ticket.date.ToString("dd.MM.yyyy"), ticket.getRoomName(_context), ticket.block, true));
                    }
                }
                else
                {
                    IdentityUser user = null;

                    var taskUser = userManager.FindByNameAsync(User.Identity.Name);
                    taskUser.Wait();
                    user = taskUser.Result;

                    var taskRole = RoleManagerP.getRole(userManager, user);
                    taskRole.Wait();
                    var role = taskRole.Result;

                    var taskOverbookable = existingTicket.isOverbookable(userManager, role);
                    taskOverbookable.Wait();
                    var Overbookable = taskOverbookable.Result;

                    if (Overbookable)
                    {
                        existingTicket.overbooked = true;
                        _context.Tickets.Update(existingTicket);
                        _context.Tickets.Add(newTicket);
                        _context.SaveChanges();

                        Ticket ticket = null;

                        foreach (var item in _context.Tickets.ToList())
                        {
                            if (item.compare(newTicket))
                            {
                                ticket = item;
                                break;
                            }
                        }

                        if (ticket != null)
                        {
                            Ticket.EditCreateDay(_context, ticket);
                            bookedList.Add(new BookingResult(ticket.date.ToString("dd.MM.yyyy"), ticket.getRoomName(_context), ticket.block, true));
                            if (!existingTicket.user.Contains("Prof") && !existingTicket.user.Contains("Tutor") && !existingTicket.user.Contains("User"))
                            {
                                Mail.AutoEmail(existingTicket, existingTicket.getRoomName(_context));
                            }

                        }

                    }
                    else
                    {
                        bookedList.Add(new BookingResult(newTicket.date.ToString("dd.MM.yyyy"), newTicket.getRoomName(_context), newTicket.block, false));
                        //return BadRequest("Huh was ist den da Passiert, da war wohl jemand etwas schneller ;)");
                    }
                }
            }

            ViewBag.bookedList = bookedList;
            sem.Release();
            return PartialView("bookingResponse");
        }


        public IActionResult removeTicket(int id)
        {

            var tickedInDb = _context.Tickets.Find(id);

            if (tickedInDb != null)
            {
                Day day = null;

                foreach (var item in _context.Days.ToList())
                {
                    if (item.date == tickedInDb.date && item.Room == tickedInDb.room)
                    {
                        day = item;
                        break;
                    }
                }

                if (day != null)
                {
                    var ticketid = day.getTicketId(tickedInDb.block);
                    var ticket = _context.Tickets.Find(ticketid);
                    if (ticket != null)
                    {
                        if (tickedInDb.user == User.Identity.Name)
                        {
                            day.setBlock(tickedInDb.block, 0);
                        }
                        else
                        {
                            return BadRequest("This is not your Ticket ;)");
                        }
                    }
                }
                //_context.Tickets.Remove(tickedInDb);
                tickedInDb.overbooked = true;
                _context.Tickets.Update(tickedInDb);
                if (day != null)
                {
                    _context.Days.Update(day);
                }

                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("booked");
        }

        [HttpPost]
        public IActionResult DateSearch(SearchValues SearchParas)
        {
            if (SearchParas != null && SearchParas.ticket.date != null && SearchParas.ticket.block != 0)
            {
                DateTime date = SearchParas.ticket.getTicketTime().AddMinutes(-90);
                List<TicketShow> items = new List<TicketShow>();

                foreach (var room in _context.Rooms.ToList())
                {
                    if (room.validateRoom(SearchParas))
                    {
                        var found = false;
                        var refDay = new DateTime(date.Year, date.Month, date.Day);
                        foreach (var day in _context.Days.ToList())
                        {
                            if (day.date == refDay && day.Room == room.Id)
                            {
                                var ticketid = day.getTicketIdByDate(date);
                                if (ticketid == 0)
                                {
                                    items.Add(new TicketShow(date.ToString("dd.MM.yyyy"), room.RoomName, TicketShow.GetTimes(SearchParas.ticket.block)));
                                }
                                found = true;
                            }
                        }

                        if (!found)
                        {
                            items.Add(new TicketShow(date.ToString("dd.MM.yyyy"), room.RoomName, TicketShow.GetTimes(SearchParas.ticket.block)));
                        }
                    }
                }

                ViewBag.items = items;
                ViewBag.rooms = _context.Rooms.ToList();
                return View();
            }
            return BadRequest("deine Angaben sind nicht möglich");
        }

        [Authorize]
        [HttpPost]
        public IActionResult BookWithTicket(TicketShow ticket)
        {
            if (ticket != null)
            {
                bool res = false;

                Ticket addTicket = null;
                foreach (var item in _context.Rooms.ToList())
                {
                    if (ticket.Room == item.RoomName)
                    {
                        addTicket = new Ticket(item.Id, User.Identity.Name, ticket.getDate(), ticket.getBlock());
                    }
                }

                Ticket newTicket = null;

                if (addTicket != null)
                {
                    var found = false;
                    foreach (var item in _context.Ticktes.ToList())
                    {
                        if (addTicket.same(item))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        _context.Tickets.Add(addTicket);
                        _context.SaveChanges();

                        foreach (var item in _context.Ticktes.ToList())
                        {
                            if (addTicket.compare(item))
                            {
                                newTicket = item;
                                break;
                            }
                        }

                        Ticket.EditCreateDay(_context, newTicket);
                        res = true;
                    }
                }

                ViewBag.response = res;
                return View("Response");
            }
            return RedirectToAction("räume");
        }

        public IActionResult fillTickets()
        {
            DummyTickets tickets = new DummyTickets(_context, userManager);

            return RedirectToAction("räume");
        }
        public IActionResult dropTicketsAndDays()
        {
            foreach (var item in _context.Tickets.ToList())
            {
                _context.Tickets.Remove(item);
            }

            foreach (var item in _context.Days.ToList())
            {
                _context.Days.Remove(item);
            }

            _context.SaveChanges();

            return RedirectToAction("räume");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task addDefaultRole(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var role = await RoleManagerP.getRole(userManager, user);
                if (role == UserRoles.empty)
                {
                    await userManager.AddToRoleAsync(user, "Student");
                }
            }
        }
    }
}