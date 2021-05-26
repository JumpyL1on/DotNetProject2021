using Backend.Core.Application.Interfaces;
using Backend.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.Core.Application.Features.Auth.Base
{
    public class BaseAuthHandler
    {
        protected UserManager<TeamMember> UserManager { get; }
        protected IJWTGenerator JWTGenerator { get; }

        protected BaseAuthHandler(UserManager<TeamMember> userManager, IJWTGenerator jwtGenerator)
        {
            UserManager = userManager;
            JWTGenerator = jwtGenerator;
        }
    }
}