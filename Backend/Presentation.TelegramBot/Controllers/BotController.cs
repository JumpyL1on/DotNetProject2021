using System;
using System.Threading.Tasks;
using Backend.Core.Application.Features.Bot.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bots.Types;

namespace Presentation.TelegramBot.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private IMediator Mediator { get; }

        public BotController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        [Route("1620195368:AAFHJ99UTdJ5W301yozMozAZXbJdjomwVpE")]
        public async Task Post([FromBody] MessageUpdate messageUpdate)
        {
            var message = (TextMessage) messageUpdate.Data;
            if (message.Text.Contains("/start"))
            {
                var user = message.From;
                if (user is not null)
                    await Mediator.Send(new CreateClientCommand(user.Id, user.FirstName, user.LastName));
            }
            else if (message.Text.Contains("/new"))
            {
                var user = message.From;
                if (user is not null)
                    await Mediator.Send(new CreateCaseCommand(user.Id));
            }
            else
            {
                var user = message.From;
                if (user is not null)
                {
                    var command = new SendMessageToManagerCommand(user.Id, message.Text, DateTime.Now);
                    await Mediator.Send(command);
                }
            }
        }
    }
}