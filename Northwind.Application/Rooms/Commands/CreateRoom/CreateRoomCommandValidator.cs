using FluentValidation;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(v => v.Name).MaximumLength(30);
        }
    }
}
