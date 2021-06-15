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
    public class UnassignCaseCommandHandler : BaseCommandHandler, IRequestHandler<UnassignCaseCommand, Unit>
    {
        private IBotClient BotClient { get; }

        public UnassignCaseCommandHandler(DbContext dbContext, IBotClient botClient) : base(dbContext)
        {
            BotClient = botClient;
        }

        public async Task<Unit> Handle(UnassignCaseCommand request, CancellationToken cancellationToken)
        {
            var @case = await DbContext
                .Set<Case>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            var teamMember = await DbContext
                .Set<TeamMember>()
                .FindAsync(new object[] {@case.TeamMemberId}, cancellationToken);
            var notification = $"За вами больше не закреплен менеджер {teamMember.UserName} в этом чате. Ожидайте нового.";
            await BotClient.HandleAsync(new SendText(@case.ClientId, notification), cancellationToken);
            @case.UnAssign();
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}