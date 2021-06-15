using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Bot.Commands;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Bot.Handlers
{
    public class SendMessageToManagerCommandHandler : BaseCommandHandler,
        IRequestHandler<SendMessageToManagerCommand, Unit>
    {
        private IHubContext<WebhooksHub> HubContext { get; }

        public SendMessageToManagerCommandHandler(DbContext dbContext, IHubContext<WebhooksHub> hubContext) : base(dbContext)
        {
            HubContext = hubContext;
        }

        public async Task<Unit> Handle(SendMessageToManagerCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await DbContext
                .Set<TeamMember>()
                .SingleAsync(member => member.Role == Role.Director, cancellationToken);
            var @case = await DbContext
                .Set<Case>()
                .SingleAsync(x => x.ClientId == request.ClientId, cancellationToken);
            await HubContext.Clients
                .User(@case.TeamMemberId.ToString())
                .SendAsync("SendText", request.Text, cancellationToken);
            await HubContext.Clients
                .User(teamMember.Id.ToString())
                .SendAsync("SendText", request.Text, cancellationToken);
            var message = new Message(@case.Id, request.Text, false, request.Sender, request.CreatedAt);
            DbContext.Entry(message).State = EntityState.Added;
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}