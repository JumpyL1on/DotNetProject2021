using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.Cases.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bots;
using Telegram.Bots.Requests;

namespace Backend.Core.Application.Features.Administration.Cases.Handlers
{
    public class AssignCaseCommandHandler : BaseCommandHandler, IRequestHandler<AssignCaseCommand, Unit>
    {
        private IBotClient BotClient { get; }

        public AssignCaseCommandHandler(DbContext dbContext, IBotClient botClient) : base(dbContext)
        {
            BotClient = botClient;
        }

        public async Task<Unit> Handle(AssignCaseCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await DbContext
                .Set<TeamMember>()
                .FindAsync(new object[] {request.AssigneeId}, cancellationToken);
            var notification = $"За вами закреплен менеджер {teamMember.UserName} в этом чате.";
            var @case = await DbContext
                .Set<Case>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            await BotClient.HandleAsync(new SendText(@case.ClientId, notification), cancellationToken);
            @case.AssignTo(request.AssigneeId);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}