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

namespace Northwind.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly NorthwindDbContext _context;

        public DeleteRoomCommandHandler(NorthwindDbContext context)
        {
            _context = context;
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
            

            return Unit.Value;
        }
    }
}
