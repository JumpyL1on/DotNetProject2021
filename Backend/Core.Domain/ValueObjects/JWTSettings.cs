namespace Backend.Core.Domain.ValueObjects
{
    public record JWTSettings
    {
        public string SecurityKey { get; init; }
        public string ValidIssuer { get; init; }
        public string ValidAudience { get; init; }
        public double ExpiryInMinutes { get; init; }
    }
}