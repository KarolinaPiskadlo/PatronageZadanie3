using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Interfaces;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public int Area { get; set; }
        public string Calendar { get; set; }


        //public class Handler : IRequestHandler<CreateRoomCommand, Unit>
        //{
        //    private readonly NorthwindDbContext _context;
        //    private readonly INotificationService _notificationService;
        //    private readonly IMediator _mediator;

        //    public Handler(
        //        NorthwindDbContext context,
        //        INotificationService notificationService,
        //        IMediator mediator)
        //    {
        //        _context = context;
        //        _notificationService = notificationService;
        //        _mediator = mediator;
        //    }

        //    public async Task<Unit> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        //    {
        //        var entity = new Room
        //        {
        //            RoomId = request.RoomId,
        //            Name = request.Name,
        //            NumberOfSeats = request.NumberOfSeats,
        //            Area = request.Area,
        //            Calendar = request.Calendar
        //        };

        //        _context.Rooms.Add(entity);

        //        await _context.SaveChangesAsync(cancellationToken);

        //        await _mediator.Publish(new RoomCreated { RoomId = entity.Name });

        //        return Unit.Value;
        //    }
        //}
    }
}
