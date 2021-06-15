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
    public class CloseCaseCommandHandler : BaseCommandHandler, IRequestHandler<CloseCaseCommand, Unit>
    {
        private IBotClient BotClient { get; }

        public CloseCaseCommandHandler(DbContext dbContext, IBotClient botClient) : base(dbContext)
        {
            BotClient = botClient;
        }

        public async Task<Unit> Handle(CloseCaseCommand request, CancellationToken cancellationToken)
        {
            var @case = await DbContext
                .Set<Case>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            const string notification = "Текущий чат закрыт. Выберите команду /new, чтобы начать новый.";
            await BotClient.HandleAsync(new SendText(@case.ClientId, notification), cancellationToken);
            @case.Close();
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}