using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<RoomViewModel>
    {
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public int Area { get; set; }
        public string Calendar { get; set; }
    }
}
