using MediatR;

namespace Backend.Core.Application.Features.Bot.Commands
{
    public record CreateClientCommand : IRequest<Unit>
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public CreateClientCommand(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}