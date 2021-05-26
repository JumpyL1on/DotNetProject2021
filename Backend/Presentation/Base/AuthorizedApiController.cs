using System;
using Backend.Core.Domain.Entities;
using Backend.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Backend.Presentation.Base
{
    [Authorize]
    public class AuthorizedApiController : BaseApiController
    {
        protected UserManager<TeamMember> UserManager { get; }
        protected Guid TeamMemberId { get; }

        public AuthorizedApiController(IMediator mediator, UserManager<TeamMember> userManager) : base(mediator)
        {
            UserManager = userManager;
            TeamMemberId = UserManager.GetUserGuid(User);
        }
    }
}