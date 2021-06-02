using System;

namespace Backend.Core.Application.Features.Administration.DTOs
{
    public record CaseDTO
    {
        public Guid Id { get; init; }
        public string Status { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}