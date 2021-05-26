using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Correspondence.Commands;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Correspondence.Handlers
{
    public class SendMessageToManagerCommandHandler : BaseCommandHandler,
        IRequestHandler<SendMessageToManagerCommand, Unit>
    {
        private IHubContext<Hub> HubContext { get; }

        public SendMessageToManagerCommandHandler(DbContext dbContext, IHubContext<Hub> hubContext) : base(dbContext)
        {
            HubContext = hubContext;
        }

        public async Task<Unit> Handle(SendMessageToManagerCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}