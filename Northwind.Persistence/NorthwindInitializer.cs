using System.Collections.Generic;
using Northwind.Domain.Entities;

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
        }
    }
}