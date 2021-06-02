namespace Backend.Core.Domain.ValueObjects
{
    public record AuthOptions
    {
        public string Key { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public double Lifetime { get; init; }
    }
}