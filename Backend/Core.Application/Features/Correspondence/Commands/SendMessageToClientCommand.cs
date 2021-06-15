using System;
using MediatR;

namespace Backend.Core.Application.Features.Correspondence.Commands
{
    public record SendMessageToClientCommand : IRequest<Unit?>
    {
        public Guid CaseId { get; init; }
        public int ClientId { get; init; }
        public string Text { get; init; }
        public string Sender { get; init; }
        public DateTime CreatedAt { get; init; }
        public Guid TeamMemberId { get; init; }
    }
}