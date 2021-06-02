using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Bot.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Bot.Handlers
{
    public class CreateCaseCommandHandler : BaseCommandHandler, IRequestHandler<CreateCaseCommand, Unit>
    {
        public CreateCaseCommandHandler(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            var @case = new Case(request.ClientId);
            DbContext.Entry(@case).State = EntityState.Added;
            var client = await DbContext
                .Set<Client>()
                .FindAsync(new object[] {request.ClientId}, cancellationToken);
            client.Foo(@case.Id);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}