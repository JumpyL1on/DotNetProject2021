using System.Threading.Tasks;
using Backend.Presentation.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bots.Types;

namespace Backend.Presentation.Controllers
{
    public class BotController : BaseApiController
    {
        public BotController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("1699936465:AAEmc-S8YUcrkFzI8Lxi97x4q82btJkrS-s")]
        public async Task Update([FromBody] MessageUpdate messageUpdate)
        {
            var message = (TextMessage) messageUpdate.Data;
            if (message.Text.Contains("/start"))
            {
                var user = message.From;
                //await Mediator.Send(new CreateClientCommand(user.Id, user.FirstName, user.LastName));
            }
            else if (message.Text.Contains("/new"))
            {
                var user = message.From;
                //await Mediator.Send(new CreateCaseCommand(user.Id));
            }
            else
            {
                var user = message.From;
                //await Mediator.Send(new CreateMessageCommand(user.Id, message.Text));
            }
        }
    }
}