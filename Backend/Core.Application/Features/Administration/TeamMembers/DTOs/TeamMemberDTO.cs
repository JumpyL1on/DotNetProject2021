using System;

namespace Backend.Core.Application.Features.Administration.TeamMembers.DTOs
{
    public record TeamMemberDTO
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }
        public string Role { get; init; }
        public DateTime AddedAt { get; init; }
        public DateTime DeletedAt { get; init; }
    }
}