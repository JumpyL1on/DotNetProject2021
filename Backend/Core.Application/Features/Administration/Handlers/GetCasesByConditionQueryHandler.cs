using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.DTOs;
using Backend.Core.Application.Features.Administration.Queries;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.Handlers
{
    internal class GetCasesByConditionQueryHandler : BaseQueryHandler,
        IRequestHandler<GetCasesByConditionQuery, CaseDTO[]>
    {
        public GetCasesByConditionQueryHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<CaseDTO[]> Handle(GetCasesByConditionQuery request,
            CancellationToken cancellationToken)
        {
            var cases = DbContext.Set<Case>();
            return request.View switch
            {
                "unassigned" => await cases
                    .Where(@case => @case.Status == Status.New)
                    .ProjectTo<CaseDTO>(Mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                "opened" => await cases
                    .Where(@case => @case.Status == Status.Open)
                    .ProjectTo<CaseDTO>(Mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                "closed" => await cases
                    .Where(@case => @case.Status == Status.Closed)
                    .ProjectTo<CaseDTO>(Mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                _ => null
            };
        }
    }
}