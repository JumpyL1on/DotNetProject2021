using System;
using MediatR;

namespace Backend.Core.Application.Features.Administration.Commands
{
    public record AssignCaseCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
        public Guid AssigneeId { get; init; }
        public Guid TeamMemberId { get; init; }
    }
}