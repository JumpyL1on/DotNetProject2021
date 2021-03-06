using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Backend.Presentation.WebAPI.Base
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthorizedApiController : BaseApiController
    {
        protected UserManager<TeamMember> UserManager { get; }

        public AuthorizedApiController(IMediator mediator, UserManager<TeamMember> userManager) : base(mediator)
        {
            UserManager = userManager;
        }
    }
}