using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(30);
        }
    }
}
