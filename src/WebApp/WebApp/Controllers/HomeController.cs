using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Dummy;
using WebApp.Models;
using WebApp.Data;

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


        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMgr, ApplicationDbContext con)
        {
            _logger = logger;
            _context = con;
            selectedRoom = new Room();
            userManager = userMgr;

            if (first == true)
            {
                //erstellen der dummy Daten
                var dummyRoles = new DummyRoles(roleMgr);
                var dummyUsers = new DummyUsers(userMgr);
                var DummyRooms = new DummyRooms(con);
                var dummyTickets = new DummyTickets(con, userMgr);
                
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
                if (item.user.Equals(User.Identity.Name))
                {
                    foreach (var elem in _context.Rooms.ToList())
                    {
                        if (elem.Id == item.room)
                        {
                            tickets.Add(new TicketShow(item.date.ToString("dd.MM.yyyy"), elem.RoomName, item.block));
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


            if (name != null)
            {

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

            //bring them to the front end
            //ViewBag.date = today;
            ViewBag.Days = betterDays;
            ViewBag.Room = selectedRoom;

            

            return PartialView("RoomView");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}