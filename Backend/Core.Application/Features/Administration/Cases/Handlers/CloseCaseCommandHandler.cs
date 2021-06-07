using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.Cases.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.Cases.Handlers
{
    public class CloseCaseCommandHandler : BaseCommandHandler, IRequestHandler<CloseCaseCommand, Unit>
    {
        public CloseCaseCommandHandler(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(CloseCaseCommand request, CancellationToken cancellationToken)
        {
            var @case = await DbContext
                .Set<Case>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            @case.Close();
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}