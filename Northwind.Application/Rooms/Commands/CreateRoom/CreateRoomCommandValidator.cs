using FluentValidation;
using System;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(v => v.Name).MaximumLength(30);
            //RuleFor(v => v.Calendar).Must(BeAValidDate).WithMessage("Invalid date");
        }

        //private static bool BeAValidDate(string calendar)
        //{
        //    DateTime date;
        //    return DateTime.TryParse(calendar, out date);
        //}

    }
}
