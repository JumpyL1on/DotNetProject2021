using System;
using MediatR;

namespace Backend.Core.Application.Features.Correspondence.Commands
{
    public class SendMessageToManagerCommand : IRequest<Unit>
    {
        public Guid TeamMemberId { get; init; }
        public string Text { get; init; }
    }
}