using Backend.Core.Application.Base;
using Microsoft.EntityFrameworkCore;
using Telegram.Bots;

namespace Backend.Core.Application.Features.Bot.Base
{
    public class BaseBotCommandHandler : BaseCommandHandler
    {
        protected IBotClient BotClient { get; }

        public BaseBotCommandHandler(DbContext dbContext, IBotClient botClient) : base(dbContext)
        {
            BotClient = botClient;
        }
    }
}