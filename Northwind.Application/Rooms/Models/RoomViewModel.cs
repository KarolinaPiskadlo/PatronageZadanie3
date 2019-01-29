using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Models
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }

        public string Name { get; set; }

        public int NumberOfSeats { get; set; }

        public int Area { get; set; }

        public string Calendar { get; set; }
    }
}
