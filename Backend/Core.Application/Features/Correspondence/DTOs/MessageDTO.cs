using System;

namespace Backend.Core.Application.Features.Correspondence.DTOs
{
    public record MessageDTO
    {
        public string Type { get; init; }
        public string Text { get; init; }
        public bool Reply { get; init; }
        public string Sender { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}