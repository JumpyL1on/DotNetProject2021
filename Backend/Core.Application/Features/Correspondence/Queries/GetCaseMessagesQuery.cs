using System;
using Backend.Core.Application.Features.Correspondence.DTOs;
using MediatR;

namespace Backend.Core.Application.Features.Correspondence.Queries
{
    public class GetCaseMessagesQuery : IRequest<MessageDTO[]>
    {
        public Guid CaseId { get; init; }
        public Guid AssigneeId { get; init; }

        public GetCaseMessagesQuery(Guid caseId, Guid assigneeId)
        {
            CaseId = caseId;
            AssigneeId = assigneeId;
        }
    }
}