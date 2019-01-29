using Northwind.Application.Rooms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Rooms.Queries.GetRooms
{
    public class RoomsListViewModel
    {
        public IEnumerable<RoomDto> Rooms { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
