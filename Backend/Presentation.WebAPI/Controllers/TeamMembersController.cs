using System;
using System.Threading.Tasks;
using Backend.Core.Application.Features.Administration.Queries;
using Backend.Core.Application.Features.Administration.TeamMembers.Commands;
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
        public async Task<IActionResult> GetByCondition([FromQuery] string view)
        {
            var request = new GetTeamMembersByConditionQuery(view, UserManager.GetUserGuid(User));
            var response = await Mediator.Send(request);
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        [HttpDelete, Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, [FromBody] DeleteTeamMemberCommand command)
        {
            command = command with {Id = id, CurrentTeamMemberId = UserManager.GetUserGuid(User)};
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost, Route("{id:guid}/restore")]
        public async Task<IActionResult> Restore([FromRoute] Guid id)
        {
            var command = new RestoreTeamMemberCommand(id, UserManager.GetUserGuid(User));
            return Ok(await Mediator.Send(command));
        }
    }
}