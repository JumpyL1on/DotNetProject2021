using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Correspondence.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bots;
using Telegram.Bots.Requests;

namespace Backend.Core.Application.Features.Correspondence.Handlers
{
    public class SendMessageToClientCommandHandler : BaseCommandHandler,
        IRequestHandler<SendMessageToClientCommand, Unit?>
    {
        private IBotClient BotClient { get; }

        public SendMessageToClientCommandHandler(DbContext dbContext, IBotClient botClient) : base(dbContext)
        {
            BotClient = botClient;
        }

        public async Task<Unit?> Handle(SendMessageToClientCommand request, CancellationToken cancellationToken)
        {
            var response = await BotClient.HandleAsync(new SendText(request.ClientId, request.Text), cancellationToken);
            if (!response.Ok)
                return null;
            var message = new Message(request.CaseId, request.Text, true, request.CreatedAt);
            DbContext.Entry(message).State = EntityState.Added;
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}