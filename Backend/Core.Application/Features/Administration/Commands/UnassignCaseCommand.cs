using System;
using MediatR;

namespace Backend.Core.Application.Features.Administration.Commands
{
    public record UnassignCaseCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
        public Guid CurrentTeamMemberId { get; init; }

        public UnassignCaseCommand(Guid id, Guid currentTeamMemberId)
        {
            Id = id;
            CurrentTeamMemberId = currentTeamMemberId;
        }
    }
}