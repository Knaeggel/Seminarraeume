using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace WebApp.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext context;

        public BookingController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ticketing()
        {
            var rooms = context.Rooms.toList();
            ViewBag.Rooms = rooms;

            return View();
        }

        public IActionResult Overview()
        {
            var tickets = context.Tickets.toList();
            ViewBag.Tickets = tickets;

            return View();
        }
    }
}
