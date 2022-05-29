using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Day> Blocks { get; set; } //brauch man net mehr
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ticket> Ticktes { get; set; } //is auch raus

        public DbSet<Day> Days { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}