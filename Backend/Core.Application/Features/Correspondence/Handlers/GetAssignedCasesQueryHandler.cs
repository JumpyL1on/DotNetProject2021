using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Correspondence.DTOs;
using Backend.Core.Application.Features.Correspondence.Queries;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Correspondence.Handlers
{
    public class GetAssignedCasesQueryHandler : BaseQueryHandler,
        IRequestHandler<GetAssignedCasesQuery, AssignedCaseDTO[]>
    {
        public GetAssignedCasesQueryHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<AssignedCaseDTO[]> Handle(GetAssignedCasesQuery request,
            CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<Case>()
                .Where(@case => @case.Status == Status.Open && @case.TeamMemberId == request.TeamMemberId)
                .ProjectTo<AssignedCaseDTO>(Mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}