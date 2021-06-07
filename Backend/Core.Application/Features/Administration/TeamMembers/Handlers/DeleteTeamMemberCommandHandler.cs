using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.TeamMembers.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.TeamMembers.Handlers
{
    public class DeleteTeamMemberCommandHandler : BaseCommandHandler, IRequestHandler<DeleteTeamMemberCommand, Unit>
    {
        public DeleteTeamMemberCommandHandler(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(DeleteTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await DbContext
                .Set<TeamMember>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            if (!request.IsPermanently)
            {
                teamMember.IsDeleted = true;
                teamMember.DeletedAt = DateTime.Now;
            }
            else
            {
                DbContext.Entry(teamMember).State = EntityState.Deleted;
                var cases = DbContext
                    .Set<Case>()
                    .Where(@case => @case.TeamMemberId == teamMember.Id);
                await cases.ForEachAsync(@case => @case.UnAssign(), cancellationToken);
            }

            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}