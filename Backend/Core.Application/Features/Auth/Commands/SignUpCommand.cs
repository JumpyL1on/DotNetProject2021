using MediatR;

namespace Backend.Core.Application.Features.Auth.Commands
{
    public record SignUpCommand : IRequest<string>
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public string Fullname { get; init; }
        public string ConfirmPassword { get; init; }
    }
}