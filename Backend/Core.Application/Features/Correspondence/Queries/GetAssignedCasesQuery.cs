using System;
using Backend.Core.Application.Features.Correspondence.DTOs;
using MediatR;

namespace Backend.Core.Application.Features.Correspondence.Queries
{
    public record GetAssignedCasesQuery : IRequest<AssignedCaseDTO[]>
    {
        public Guid TeamMemberId { get; init; }

        public GetAssignedCasesQuery(Guid teamMemberId)
        {
            TeamMemberId = teamMemberId;
        }
    }
}