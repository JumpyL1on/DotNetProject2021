using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Features.Auth.Base;
using Backend.Core.Application.Features.Auth.Commands;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Backend.Core.Application.Features.Auth.Handlers
{
    internal class SignInCommandCommandHandler : BaseAuthCommandHandler, IRequestHandler<SignInCommand, string>
    {
        public SignInCommandCommandHandler(UserManager<TeamMember> userManager, IJWTGenerator jwtGenerator) : base(userManager,
            jwtGenerator)
        {
        }

        public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await UserManager.FindByEmailAsync(request.Email);
            return JWTGenerator.CreateToken(teamMember);
        }
    }
}