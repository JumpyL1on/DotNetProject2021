using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.Cases.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.Cases.Handlers
{
    public class AssignCaseCommandHandler : BaseCommandHandler, IRequestHandler<AssignCaseCommand, Unit>
    {
        public AssignCaseCommandHandler(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(AssignCaseCommand request, CancellationToken cancellationToken)
        {
            var @case = await DbContext
                .Set<Case>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            @case.AssignTo(request.AssigneeId);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}