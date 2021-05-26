using System;

namespace Backend.Core.Application.Features.Correspondence.DTOs
{
    public record AssignedCaseDTO
    {
        public Guid Id { get; init; }
        public ClientDTO Client { get; init; }
    }
}