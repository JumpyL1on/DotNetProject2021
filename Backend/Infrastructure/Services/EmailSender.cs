using System.Threading.Tasks;
using Backend.Core.Application.Interfaces;

namespace Backend.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
        }
    }
}