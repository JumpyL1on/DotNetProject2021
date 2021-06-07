using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.Cases.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.Cases.Handlers
{
    public class UnassignCaseCommandHandler : BaseCommandHandler, IRequestHandler<UnassignCaseCommand, Unit>
    {
        public UnassignCaseCommandHandler(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(UnassignCaseCommand request, CancellationToken cancellationToken)
        {
            var @case = await DbContext
                .Set<Case>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            @case.UnAssign();
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}