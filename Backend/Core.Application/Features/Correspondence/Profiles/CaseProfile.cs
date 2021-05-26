using AutoMapper;
using Backend.Core.Application.Features.Correspondence.DTOs;
using Backend.Core.Domain.Entities;

namespace Backend.Core.Application.Features.Correspondence.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<Case, AssignedCaseDTO>()
                .ForMember(dto => dto.Id, expression => expression.MapFrom(@case => @case.Id))
                .ForMember(dto => dto.Client, expression => expression.MapFrom(@case => @case.Client));
        }
    }
}