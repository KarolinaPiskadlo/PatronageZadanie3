using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Queries.GetRoomCalendar
{
    public class GetRoomCalendarQuery : IRequest<IEnumerable<CalendarViewModel>>
    {
        public int Id { get; set; }
    }
}
