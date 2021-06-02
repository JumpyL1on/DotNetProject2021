namespace Backend.Core.Application.Features.Correspondence.DTOs
{
    public record ClientDTO
    {
        public int Id { get; init; }
        public string FullName { get; init; }
    }
}