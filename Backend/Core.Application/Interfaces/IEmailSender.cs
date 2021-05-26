using System.Threading.Tasks;

namespace Backend.Core.Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}