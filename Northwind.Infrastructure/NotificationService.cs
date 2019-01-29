using Northwind.Application.Interfaces;
using Northwind.Application.Notifications.Models;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Northwind.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
