using System;
using Backend.Core.Application.Features.Administration.TeamMembers.DTOs;
using MediatR;

namespace Backend.Core.Application.Features.Administration.Queries
{
    public record GetTeamMembersByConditionQuery : IRequest<TeamMemberDTO[]>
    {
        public string View { get; init; }
        public Guid TeamMemberId { get; init; }

        public GetTeamMembersByConditionQuery(string view, Guid teamMemberId)
        {
            View = view;
            TeamMemberId = teamMemberId;
        }
    }
}