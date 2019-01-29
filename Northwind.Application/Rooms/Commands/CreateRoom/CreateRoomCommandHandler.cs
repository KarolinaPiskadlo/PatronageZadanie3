using AutoMapper;
using MediatR;
using Northwind.Application.Rooms.Models;
using Northwind.Application.Rooms.Services;
using Northwind.Domain.Entities;
using Northwind.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomViewModel>
    {
        private readonly NorthwindDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public CreateRoomCommandHandler(
            NorthwindDbContext context,
            IEmailService emailService,
            IMapper mapper)
        {
            _context = context;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<RoomViewModel> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = new Room
            {
                Name = request.Name,
                NumberOfSeats = request.NumberOfSeats,
                Area = request.Area,
                Calendar = request.Calendar
            };

            char[] separator = new char[] { ',' };
            string[] dates;

            dates = entity.Calendar.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (var oneDate in dates)
            {
                try
                {
                    DateTime.Parse(oneDate.Trim());
                }
                catch
                {
                    throw new Exception("Not correct date format");
                }
            }

            _context.Rooms.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _emailService.SendEmail(
                "zadanie3.patronage@gmail.com",
                "Notification: New room has been created",
                $"A room with id = {entity.RoomId} has been created"
                );

            return _mapper.Map<RoomViewModel>(entity);
        }
    }
}

