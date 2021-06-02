using MediatR;

namespace Backend.Core.Application.Features.Bot.Commands
{
    public record CreateCaseCommand : IRequest<Unit>
    {
        public int ClientId { get; init; }

        public CreateCaseCommand(int clientId)
        {
            ClientId = clientId;
        }
    }
}