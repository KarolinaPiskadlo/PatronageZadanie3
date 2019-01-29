using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Rooms.Models;
using Northwind.Persistence;
using Dapper;

namespace Northwind.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, IEnumerable<RoomViewModel>>
    {
        private readonly NorthwindDbContext _context;

        public GetRoomsQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<RoomViewModel>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var sql = @"SELECT * FROM Rooms";

            return _context.Database.GetDbConnection().QueryAsync<RoomViewModel>(sql);
        }
    }
}
