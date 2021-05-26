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
    internal class SignInCommandHandler : BaseAuthHandler, IRequestHandler<SigInCommand, string>
    {
        private SignInManager<TeamMember> SignInManager { get; }

        public SignInCommandHandler(UserManager<TeamMember> userManager, IJWTGenerator jwtGenerator,
            SignInManager<TeamMember> signInManager) : base(userManager, jwtGenerator)
        {
            SignInManager = signInManager;
        }

        public async Task<string> Handle(SigInCommand request, CancellationToken cancellationToken)
        {
            var (email, password) = request;
            var user = await UserManager.FindByEmailAsync(email);
            var result = await SignInManager.CheckPasswordSignInAsync(user, password, false);
            return result.Succeeded ? JWTGenerator.CreateToken(user) : null;
        }
    }
}