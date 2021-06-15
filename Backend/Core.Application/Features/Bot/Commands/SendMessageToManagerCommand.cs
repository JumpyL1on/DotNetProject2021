using System;
using MediatR;

namespace Backend.Core.Application.Features.Bot.Commands
{
    public record SendMessageToManagerCommand : IRequest<Unit>
    {
        public int ClientId { get; init; }
        public string Text { get; init; }
        public string Sender { get; init; }
        public DateTime CreatedAt { get; init; }

        public SendMessageToManagerCommand(int clientId, string text, string sender, DateTime createdAt)
        {
            ClientId = clientId;
            Text = text;
            Sender = sender;
            CreatedAt = createdAt;
        }
    }
}