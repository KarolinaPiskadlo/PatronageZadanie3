using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Domain.Entities;
using Northwind.Persistence.Infrastructure;

namespace Northwind.Persistence
{
    public class NorthwindInitializer
    {
        private readonly Dictionary<int, Room> Rooms = new Dictionary<int, Room>();

        public static void Initialize(NorthwindDbContext context)
        {
            var initializer = new NorthwindInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(NorthwindDbContext context)
        {
            context.Database.EnsureCreated();



            //if (context.Rooms.Any())
            //{
            //    return; // Db has been seeded
            //}

            //SeedRooms(context);
        }

        //public void SeedRooms(NorthwindDbContext context)
        //{
        //    var rooms = new[]
        //    {
        //        new Room {RoomId = 1, Name = "Zielony", NumberOfSeats = 50, Area = 40, Calendar = "01022019" },
        //        new Room {RoomId = 2, Name = "Czerwony", NumberOfSeats = 50, Area = 40, Calendar = "05032019" },
        //        //new Room {RoomId = 2, Name = "Niebieski", NumberOfSeats = 20, Area = 20, WifiAccess = true, Calendar = { "06-02-2019", "08-02-2019", "09-02-2019" } },
        //        //new Room {RoomId = 3, Name = "Czerwony", NumberOfSeats = 10, Area = 15, WifiAccess = false, Calendar = { "10-02-2019", "11-02-2019"} }
        //    };

        //    context.Rooms.AddRange(rooms);

        //    context.SaveChanges();
        //}


       
        //private static byte[] StringToByteArray(string hex)
        //{
        //    return Enumerable.Range(0, hex.Length)
        //        .Where(x => x % 2 == 0)
        //        .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
        //        .ToArray();
        //}
    }
}