using MediatR;

namespace Backend.Core.Application.Features.Auth.Commands
{
    public record SignInCommand(string Email, string Password) : IRequest<string>;
}