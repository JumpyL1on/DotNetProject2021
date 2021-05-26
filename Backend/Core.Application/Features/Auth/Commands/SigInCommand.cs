using MediatR;

namespace Backend.Core.Application.Features.Auth.Commands
{
    public record SigInCommand(string Email, string Password) : IRequest<string>;
}