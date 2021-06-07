using System;
using System.Threading.Tasks;
using Backend.Core.Application.Features.Administration.Cases.Commands;
using Backend.Core.Application.Features.Correspondence.Commands;
using Backend.Core.Application.Features.Correspondence.Queries;
using Backend.Core.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Backend.Presentation.WebAPI.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GetCasesByConditionQuery = Backend.Core.Application.Features.Administration.Queries.GetCasesByConditionQuery;

namespace Backend.Presentation.WebAPI.Controllers
{
    public class CasesController : AuthorizedApiController
    {
        public CasesController(IMediator mediator, UserManager<TeamMember> userManager) : base(mediator, userManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetByCondition([FromQuery] string view)
        {
            return view == "assigned-to-me"
                ? Ok(await Mediator.Send(new GetAssignedCasesQuery(UserManager.GetUserGuid(User))))
                : Ok(await Mediator.Send(new GetCasesByConditionQuery(view, UserManager.GetUserGuid(User))));
        }

        [HttpGet, Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetAssignedCaseByIdQuery(id)));
        }

        [HttpGet, Route("{id:guid}/messages")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetCaseMessagesQuery(id, UserManager.GetUserGuid(User))));
        }

        [HttpPost, Route("{id:guid}/messages")]
        public async Task<IActionResult> Post([FromRoute] Guid id, [FromBody] SendMessageToClientCommand command)
        {
            return Ok(await Mediator.Send(command with {CaseId = id, TeamMemberId = UserManager.GetUserGuid(User)}));
        }

        [HttpPost, Route("{id:guid}/assign")]
        public async Task<IActionResult> AssignCase([FromRoute] Guid id, [FromBody] AssignCaseCommand command)
        {
            return Ok(await Mediator.Send(command with {Id = id, TeamMemberId = UserManager.GetUserGuid(User)}));
        }

        [HttpPost, Route("{id:guid}/unassign")]
        public async Task<IActionResult> UnassignCase([FromRoute] Guid id)
        {
            var command = new UnassignCaseCommand(id, UserManager.GetUserGuid(User));
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost, Route("{id:guid}/close")]
        public async Task<IActionResult> CloseCase([FromRoute] Guid id)
        {
            var command = new CloseCaseCommand(id, UserManager.GetUserGuid(User));
            return Ok(await Mediator.Send(command));
        }
    }
}