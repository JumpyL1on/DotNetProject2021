using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Correspondence.Commands;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bots;
using Telegram.Bots.Requests;

namespace Backend.Core.Application.Features.Correspondence.Handlers
{
    public class SendMessageToClientCommandHandler : BaseCommandHandler,
        IRequestHandler<SendMessageToClientCommand, Unit?>
    {
        private IBotClient BotClient { get; }
        private IHubContext<WebhooksHub> HubContext { get; }

        public SendMessageToClientCommandHandler(DbContext dbContext, IBotClient botClient, IHubContext<WebhooksHub> hubContext) : base(dbContext)
        {
            BotClient = botClient;
            HubContext = hubContext;
        }

        public async Task<Unit?> Handle(SendMessageToClientCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await DbContext
                .Set<TeamMember>()
                .SingleAsync(member => member.Role == Role.Director, cancellationToken);
            await HubContext.Clients
                .User(teamMember.Id.ToString())
                .SendAsync("NotifyDirector", request.Text, cancellationToken);
            var response = await BotClient.HandleAsync(new SendText(request.ClientId, request.Text), cancellationToken);
            if (!response.Ok)
                return null;
            var message = new Message(request.CaseId, request.Text, true, request.Sender, request.CreatedAt);
            DbContext.Entry(message).State = EntityState.Added;
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}