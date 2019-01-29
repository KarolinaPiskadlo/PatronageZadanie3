using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(v => v.RoomId).NotEmpty();
            RuleFor(v => v.Name).MaximumLength(30);
        }
    }
}
