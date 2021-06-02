using System.Threading.Tasks;
using Backend.Core.Application.Features.Auth.Commands;
using Backend.Presentation.WebAPI.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.WebAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost, Route("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            var result = await Mediator.Send(command);
            if (result == null)
                return BadRequest();
            return Ok(new {token = result});
        }

        [HttpPost, Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
        {
            var result = await Mediator.Send(command);
            if (result == null)
                return BadRequest();
            return Ok(new {token = result});
        }

        [HttpPost, Route("sign-out")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}