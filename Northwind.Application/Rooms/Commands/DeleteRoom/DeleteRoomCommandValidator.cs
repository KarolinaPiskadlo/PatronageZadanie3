using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
