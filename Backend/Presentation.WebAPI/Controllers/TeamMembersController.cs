using System.Threading.Tasks;
using Backend.Core.Application.Features.Administration.Queries;
using Backend.Core.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Backend.Presentation.WebAPI.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.WebAPI.Controllers
{
    [Route("api/team-members")]
    public class TeamMembersController : AuthorizedApiController
    {
        public TeamMembersController(IMediator mediator, UserManager<TeamMember> userManager) : base(mediator, userManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string view)
        {
            var request = new GetTeamMembersByConditionQuery(view, UserManager.GetUserGuid(User));
            var response = await Mediator.Send(request);
            if (response == null)
                return BadRequest();
            return Ok(response);
        }
    }
}