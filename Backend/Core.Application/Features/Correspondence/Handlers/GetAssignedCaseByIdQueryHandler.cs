using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Correspondence.DTOs;
using Backend.Core.Application.Features.Correspondence.Queries;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Correspondence.Handlers
{
    public class GetAssignedCaseByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetAssignedCaseByIdQuery, AssignedCaseDTO>
    {
        public GetAssignedCaseByIdQueryHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<AssignedCaseDTO> Handle(GetAssignedCaseByIdQuery request, CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<Case>()
                .Include(@case => @case.Client)
                .ProjectTo<AssignedCaseDTO>(Mapper.ConfigurationProvider)
                .SingleAsync(@case => @case.Id == request.Id, cancellationToken);
        }
    }
}