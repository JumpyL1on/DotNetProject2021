using MediatR;

namespace Backend.Core.Application.Features.Correspondence.Commands
{
    public record SendMessageToClientCommand : IRequest<Unit?>
    {
        public int ClientId { get; init; }
        public string Text { get; init; }
    }
}