using System;
using MediatR;

namespace Backend.Core.Application.Features.Administration.Cases.Commands
{
    public record CloseCaseCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
        public Guid CurrentTeamMemberId { get; init; }

        public CloseCaseCommand(Guid id, Guid currentTeamMemberId)
        {
            Id = id;
            CurrentTeamMemberId = currentTeamMemberId;
        }
    }
}