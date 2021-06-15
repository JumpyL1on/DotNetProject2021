using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Bot.Base;
using Backend.Core.Application.Features.Bot.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bots;
using Telegram.Bots.Requests;

namespace Backend.Core.Application.Features.Bot.Handlers
{
    public class CreateCaseCommandHandler : BaseBotCommandHandler, IRequestHandler<CreateCaseCommand, Unit>
    {
        public CreateCaseCommandHandler(DbContext dbContext, IBotClient botClient) : base(dbContext, botClient)
        {
        }

        public async Task<Unit> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            const string reply = "Ожидайте закрепления менеджера за вами в этом чате.";
            await BotClient.HandleAsync(new SendText(request.ClientId, reply), cancellationToken);
            var @case = new Case(request.ClientId);
            DbContext.Entry(@case).State = EntityState.Added;
            var client = await DbContext
                .Set<Client>()
                .FindAsync(new object[] {request.ClientId}, cancellationToken);
            client.Foo(@case.Id);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}