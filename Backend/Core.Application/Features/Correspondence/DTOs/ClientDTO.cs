namespace Backend.Core.Application.Features.Correspondence.DTOs
{
    public record ClientDTO
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}