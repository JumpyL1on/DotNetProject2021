using System;
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
    public class CreateClientCommandHandler : BaseBotCommandHandler, IRequestHandler<CreateClientCommand, Unit>
    {
        public CreateClientCommandHandler(DbContext dbContext, IBotClient botClient) : base(dbContext, botClient)
        {
        }

        public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            const string greeting = "Вас приветствует компания N. Выберите команду /new, чтобы начать новый чат.";
            await BotClient.HandleAsync(new SendText(request.Id, greeting), cancellationToken);
            var client = new Client(request.Id, request.FirstName, request.LastName);
            DbContext.Entry(client).State = EntityState.Added;
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}