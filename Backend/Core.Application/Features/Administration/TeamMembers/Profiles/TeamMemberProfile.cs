using AutoMapper;
using Backend.Core.Application.Features.Administration.TeamMembers.DTOs;
using Backend.Core.Domain.Entities;

namespace Backend.Core.Application.Features.Administration.TeamMembers.Profiles
{
    public class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, TeamMemberDTO>()
                .ForMember(dto => dto.Id, expression => expression.MapFrom(member => member.Id))
                .ForMember(dto => dto.FullName, expression => expression.MapFrom(member => member.UserName))
                .ForMember(dto => dto.Role, expression => expression.MapFrom(member => member.Role.ToString()));
        }
    }
}