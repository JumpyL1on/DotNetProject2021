using System;
using MediatR;

namespace Backend.Core.Application.Features.Administration.TeamMembers.Commands
{
    public record RestoreTeamMemberCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
        public Guid CurrentTeamMemberId { get; init; }

        public RestoreTeamMemberCommand(Guid id, Guid currentTeamMemberId)
        {
            Id = id;
            CurrentTeamMemberId = currentTeamMemberId;
        }
    }
}