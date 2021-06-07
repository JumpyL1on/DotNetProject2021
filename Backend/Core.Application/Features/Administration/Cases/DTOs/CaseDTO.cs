using System;
using Backend.Core.Application.Features.Administration.TeamMembers.DTOs;
using Backend.Core.Application.Features.Correspondence.DTOs;

namespace Backend.Core.Application.Features.Administration.Cases.DTOs
{
    public record CaseDTO
    {
        public Guid Id { get; init; }
        public TeamMemberDTO TeamMember { get; init; }
        public ClientDTO Client { get; init; }
        public string Status { get; init; }
        public LastMessageDTO LastMessage { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}