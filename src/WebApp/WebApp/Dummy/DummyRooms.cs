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
                room.RoomSize = 25;
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
                room.RoomSize = 10;
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
                room.RoomName = "B20" + (i + 1);
                room.KindOfRoom = "PC-Raum";
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
                room.RoomName = "B04" + (i + 1);
                room.KindOfRoom = "Labor";
                room.Status = false;
                room.RoomSize = 55;
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

            for (int i = 4; i < 10; i++)
            {
                Room room = new Room();
                room.RoomName = "C10" + (i + 1);
                room.KindOfRoom = "Vorlesungssaal";
                room.Status = false;
                room.RoomSize = 125;
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


            for (int i = 4; i < 10; i++)
            {
                Room room = new Room();
                room.RoomName = "C00" + (i + 1);
                room.KindOfRoom = "Vorlesungssaal";
                room.Status = false;
                room.RoomSize = 15;
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


            for (int i = 0; i < 10; i++)
            {
                Room room = new Room();
                room.RoomName = "D00" + (i + 1);
                room.KindOfRoom = "Medienraum";
                room.Status = false;
                room.RoomSize = 23;
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


            for (int i = 4; i < 10; i++)
            {
                Room room = new Room();
                room.RoomName = "D10" + (i + 1);
                room.KindOfRoom = "Vorlesungssaal";
                room.Status = false;
                room.RoomSize = 60;
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

            for (int i = 2; i < 8; i++)
            {
                Room room = new Room();
                room.RoomName = "E00" + (i + 1);
                room.KindOfRoom = "PC-Raum";
                room.Status = false;
                room.RoomSize = 25;
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

            for (int i = 1; i < 8; i++)
            {
                Room room = new Room();
                room.RoomName = "E30" + (i + 1);
                room.KindOfRoom = "Vorlesungssaal";
                room.Status = false;
                room.RoomSize = 45;
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
