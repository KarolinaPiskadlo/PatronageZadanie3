using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Rooms.Models;
using System.Collections.Generic;
using Dapper;

namespace Northwind.Application.Rooms.Queries.GetRoomCalendar
{
    public class GetRoomCalendarQueryHandler : IRequestHandler<GetRoomCalendarQuery, IEnumerable<CalendarViewModel>>
    {
        private readonly NorthwindDbContext _context;

        public GetRoomCalendarQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CalendarViewModel>> Handle(GetRoomCalendarQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Rooms.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            var sql = $@"
            SELECT Calendar 
            FROM Rooms
            WHERE RoomID = {request.Id}";

            return _context.Database.GetDbConnection().QueryAsync<CalendarViewModel>(sql);

            
        }
    }
}
