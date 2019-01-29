using MediatR;
using Northwind.Application.Rooms.Models;
using Northwind.Domain.Entities;
using System.Collections.Generic;

namespace Northwind.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsQuery : IRequest<IEnumerable<RoomViewModel>>
    {
    }
}
