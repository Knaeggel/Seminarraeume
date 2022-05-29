using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Dummy;
using WebApp.Models;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static bool first = true;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private Room selectedRoom;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMgr, ApplicationDbContext con)
        {
            _logger = logger;
            _context = con;
            selectedRoom = new Room();

            if (first == true)
            {
                var dummyRoles = new DummyRoles(roleMgr);
                var dummyUsers = new DummyUsers(userMgr);
                var DummyRooms = new DummyRooms(con);
                var dummyTickets = new DummyTickets(con, userMgr);
                
            }

            first = false;
        }

        [Authorize]
        public IActionResult booked()
        {
            ViewBag.Tickets = _context.Tickets.ToList();
            return View();
        }

        public IActionResult räume(string name)
        {
            var today = new DateTime();
            today = DateTime.Now;
            List<Day> days = new List<Day>();


            if (name != null)
            {
                foreach (var item in _context.Rooms.ToList())
                {
                    if (item.RoomName == name)
                    {
                        selectedRoom = item;
                        break;
                    }
                }

                foreach (var item in _context.Days.ToList())
                {
                    if (item.Room == selectedRoom.Id && item.date.Day > today.Day && item.date.Day < today.Day + 7)
                    {
                        days.Add(item);
                    }
                }
            }

            ViewBag.Rooms = _context.Rooms.ToList();
            ViewBag.date = today;
            ViewBag.Days = days;
            ViewBag.Room = selectedRoom;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}