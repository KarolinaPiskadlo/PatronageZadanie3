using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Queries.GetRoomDetails
{
    public class GetRoomDetailsQuery : IRequest<RoomViewModel>
    {
        public int Id { get; set; }
    }
}
