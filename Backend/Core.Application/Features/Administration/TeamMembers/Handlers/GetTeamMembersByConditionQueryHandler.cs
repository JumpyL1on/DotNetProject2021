using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Administration.Queries;
using Backend.Core.Application.Features.Administration.TeamMembers.DTOs;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.TeamMembers.Handlers
{
    public class GetTeamMembersByConditionQueryHandler : BaseQueryHandler, IRequestHandler<GetTeamMembersByConditionQuery, TeamMemberDTO[]>
    {
        public GetTeamMembersByConditionQueryHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<TeamMemberDTO[]> Handle(GetTeamMembersByConditionQuery request, CancellationToken cancellationToken)
        {
            var teamMembers = DbContext.Set<TeamMember>();
            return request.View switch
            {
                "enabled" => await teamMembers
                    .Where(member => !member.IsDeleted && member.Role == Role.Manager)
                    .ProjectTo<TeamMemberDTO>(Mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                "deleted" => await teamMembers
                    .Where(member => member.IsDeleted)
                    .ProjectTo<TeamMemberDTO>(Mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken),
                _ => null
            };
        }
    }
}