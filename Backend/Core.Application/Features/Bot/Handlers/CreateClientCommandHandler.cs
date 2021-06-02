using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Bot.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Bot.Handlers
{
    public class CreateClientCommandHandler : BaseCommandHandler, IRequestHandler<CreateClientCommand, Unit>
    {
        public CreateClientCommandHandler(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Id, request.FirstName, request.LastName);
            DbContext.Entry(client).State = EntityState.Added;
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}