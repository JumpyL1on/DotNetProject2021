using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Base
{
    [ApiController, Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected IMediator Mediator { get; }

        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}