using System;
using System.Threading.Tasks;
using Backend.Core.Application.Features.Administration.Commands;
using Backend.Core.Application.Features.Correspondence.Queries;
using Backend.Core.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Backend.Presentation.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GetCasesByConditionQuery = Backend.Core.Application.Features.Administration.Queries.GetCasesByConditionQuery;

namespace Backend.Presentation.Controllers
{
    public class CasesController : AuthorizedApiController
    {
        public CasesController(IMediator mediator, UserManager<TeamMember> userManager) : base(mediator, userManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string view)
        {
            return view == "assigned-to-me"
                ? Ok(await Mediator.Send(new GetAssignedCasesQuery(UserManager.GetUserGuid(User))))
                : Ok(await Mediator.Send(new GetCasesByConditionQuery(view, UserManager.GetUserGuid(User))));
        }

        [HttpGet, Route("{id:guid}/messages")]
        public async Task<IActionResult> GetMessages([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetCaseMessagesQuery(id, UserManager.GetUserGuid(User))));
        }

        [HttpPost, Route("{id:guid}/assign")]
        public async Task<IActionResult> AssignCase([FromRoute] Guid id, [FromBody] AssignCaseCommand command)
        {
            return Ok(await Mediator.Send(command with {Id = id, TeamMemberId = UserManager.GetUserGuid(User)}));
        }
    }
}