using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.Commands;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.Handlers
{
    public class RestoreTeamMemberCommandHandler : BaseCommandHandler, IRequestHandler<RestoreTeamMemberCommand, Unit>
    {
        public RestoreTeamMemberCommandHandler(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(RestoreTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await DbContext
                .Set<TeamMember>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            teamMember.IsDeleted = false;
            teamMember.AddedAt = DateTime.Now;
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}