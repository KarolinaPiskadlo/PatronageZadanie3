using System.Threading.Tasks;

namespace Northwind.Application.Rooms.Services
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string message);
    }
}
