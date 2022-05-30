﻿using Microsoft.AspNetCore.Authorization;
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

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMgr, ApplicationDbContext con)
        {
            _logger = logger;
            _context = con;

            if (first == true)
            {
                var dummyRoles = new DummyRoles(roleMgr);
                var dummyUsers = new DummyUsers(userMgr);
                var DummyRooms = new DummyRooms(con);
                var dummyTickets = new DummyTickets(con);
            }

            first = false;
        }

        [Authorize]
        public IActionResult booked()
        {
            ViewBag.Tickets = _context.Ticktes.ToList();
            return View();
        }

        public async Task<IActionResult> räume(int pageNumber = 1)
        {
            ViewBag.Rooms = _context.Rooms.ToList();
            return View(await PaginatedList<Room>.CreateAsync(_context.Rooms, pageNumber, 5));
        }

        public IActionResult Bookingprocess()
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