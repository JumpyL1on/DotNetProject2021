using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Features.Auth.Base;
using Backend.Core.Application.Features.Auth.Commands;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Backend.Core.Application.Features.Auth.Handlers
{
    internal class SignUpCommandHandler : BaseAuthHandler, IRequestHandler<SignUpCommand, string>
    {
        public SignUpCommandHandler(UserManager<TeamMember> userManager, IJWTGenerator jwtGenerator) : base(userManager,
            jwtGenerator)
        {
        }

        public async Task<string> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new TeamMember(request.Fullname) {Role = Role.Manager, Email = request.Email};
            var result = await UserManager.CreateAsync(user, request.Password);
            return result.Succeeded ? JWTGenerator.CreateToken(user) : null;
        }
    }
}