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

            for (int i = 0; i < 5; i++)
            {
                Room room = new Room();
                room.RoomName = "A10" + ( i + 1);
                room.KindOfRoom = "Vorlesungssaal";
                room.Status = false;
                room.RoomSize = 30;
                bool found = false;
                foreach (var item in dbSet.Rooms.ToList())
                {
                    if (item.RoomName == room.RoomName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    dbSet.Rooms.Add(room);
                    dbSet.SaveChanges();
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Room room = new Room();
                room.RoomName = "A10" + (i + 1);
                room.KindOfRoom = "Labor";
                room.Status = false;
                room.RoomSize = 30;
                bool found = false;
                foreach (var item in dbSet.Rooms.ToList())
                {
                    if (item.RoomName == room.RoomName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    dbSet.Rooms.Add(room);
                    dbSet.SaveChanges();
                }
            }
        }

    }
}
