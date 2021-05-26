using AutoMapper;
using Backend.Core.Application.Features.Administration.DTOs;
using Backend.Core.Domain.Entities;

namespace Backend.Core.Application.Features.Administration.Profiles
{
    public class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, TeamMemberDTO>()
                .ForMember(dto => dto.Id, expression => expression.MapFrom(member => member.Id))
                .ForMember(dto => dto.UserName, expression => expression.MapFrom(member => member.UserName));
        }
    }
}