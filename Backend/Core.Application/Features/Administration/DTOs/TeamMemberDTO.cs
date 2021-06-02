using System;

namespace Backend.Core.Application.Features.Administration.DTOs
{
    public record TeamMemberDTO
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
    }
}