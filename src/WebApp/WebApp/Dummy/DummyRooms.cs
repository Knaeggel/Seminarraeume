using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Dummy
{
    public class DummyRooms
    {
        public DummyRooms(ApplicationDbContext dbSet)
        {
            FillDummy(dbSet);
        }

        public void FillDummy(ApplicationDbContext dbSet)
        {

            for(int i = 0; i < 10; i++)
            {
                Room room = new Room();
                room.RoomName = "A"+i;
                room.KindOfRoom = "Labor";
                room.Status = false;
                room.RoomSize = 20;
                dbSet.Rooms.Add(room);
                dbSet.SaveChanges();
            }

        }




    }
}
