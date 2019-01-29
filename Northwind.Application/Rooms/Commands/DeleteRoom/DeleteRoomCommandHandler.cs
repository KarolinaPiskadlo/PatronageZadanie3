using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using Northwind.Application.Rooms.Services;

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly NorthwindDbContext _context;
        private readonly IEmailService _emailService;

        public DeleteRoomCommandHandler(NorthwindDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            //var hasOrders = _context.Orders.Any(o => o.RoomId == entity.RoomId);
            //if (hasOrders)
            //{
            //    throw new DeleteFailureException(nameof(Room), request.Id, "There are existing orders associated with this customer.");
            //}

            _context.Rooms.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _emailService.SendEmail(
                "zadanie3.patronage@gmail.com",
                "Notification: New room has been deleted",
                $"A room with id = {entity.RoomId} has been deleted"
                );


            return Unit.Value;
        }
    }
}
