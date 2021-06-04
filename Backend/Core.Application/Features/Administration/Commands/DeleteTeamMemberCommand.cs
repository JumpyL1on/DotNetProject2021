using System;
using MediatR;

namespace Backend.Core.Application.Features.Administration.Commands
{
    public record DeleteTeamMemberCommand : IRequest<Unit>
    {
        public Guid Id { get; init; }
        public bool IsPermanently { get; init; }
        public Guid CurrentTeamMemberId { get; init; }
    }
}