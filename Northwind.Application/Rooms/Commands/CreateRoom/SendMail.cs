using MediatR;
using Northwind.Application.Interfaces;
using Northwind.Application.Notifications.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Commands.CreateRoom
{
    public class SendMail : INotification
    {

        public class SendMailHandler : INotificationHandler<SendMail>
        {
            private readonly INotificationService _notification;

            public SendMailHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(SendMail notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
