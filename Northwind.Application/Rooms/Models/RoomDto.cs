using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Application.Rooms.Models
{
    public class RoomDto
    {
        public int RoomId { get; set; }

        public string Name { get; set; }

        public int? NumberOfSeats { get; set; }

        public int? Area { get; set; }

        public string Calendar { get; set; }

        public static Expression<Func<Room, RoomDto>> Projection
        {
            get
            {
                return p => new RoomDto
                {
                    RoomId = p.RoomId,
                    Name = p.Name,
                    NumberOfSeats = p.NumberOfSeats,
                    Area = p.Area,
                    Calendar = p.Calendar
                };
            }
        }
    }
}
