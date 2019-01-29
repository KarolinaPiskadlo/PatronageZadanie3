using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public int Id { get; set; }
    }
}
