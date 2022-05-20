using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Models;
using WebApp.Dummy;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(ApplicationDbContext con)
        {
            DummyRooms dummyRooms = new DummyRooms();
            dummyRooms.FillDummy(con);
        }

        [Authorize]
        public IActionResult booked()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}