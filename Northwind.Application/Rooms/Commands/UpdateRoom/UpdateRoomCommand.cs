using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest<RoomViewModel>
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public int Area { get; set; }
        public string Calendar { get; set; }
    }
}
