using System;
using Backend.Core.Application.Features.Administration.DTOs;
using MediatR;

namespace Backend.Core.Application.Features.Administration.Queries
{
    public record GetCasesByConditionQuery : IRequest<CaseDTO[]>
    {
        public string View { get; init; }
        public Guid TeamMemberId { get; init; }

        public GetCasesByConditionQuery(string view, Guid teamMemberId)
        {
            View = view;
            TeamMemberId = teamMemberId;
        }
    }
}