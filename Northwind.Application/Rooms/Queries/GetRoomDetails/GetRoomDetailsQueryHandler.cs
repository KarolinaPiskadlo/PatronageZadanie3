using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Queries.GetRoomDetails
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomViewModel>
    {
        private readonly NorthwindDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomDetailsQueryHandler(NorthwindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomViewModel> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<RoomViewModel>(await _context
                .Rooms.Where(p => p.RoomId == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            return room;
        }
    }
}
