using System;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Tests.Infrastructure
{
    public class NorthwindContextFactory
    {
        public static NorthwindDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NorthwindDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new NorthwindDbContext(options);

            context.Database.EnsureCreated();

            context.Rooms.AddRange(new[] {
                new Room { RoomId = 1, WifiAccess = true },
                new Room { RoomId = 2, WifiAccess = false },
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(NorthwindDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}