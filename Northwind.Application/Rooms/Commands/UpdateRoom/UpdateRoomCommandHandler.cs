using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly NorthwindDbContext _context;

        public UpdateRoomCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms
                .SingleAsync(c => c.RoomId == request.RoomId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            entity.Name = request.Name;
            entity.NumberOfSeats = request.NumberOfSeats;
            entity.Area = request.Area;
            entity.Calendar = request.Calendar;

            _context.Rooms.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
