using AutoMapper;
using Backend.Core.Application.Features.Administration.DTOs;
using Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Message = Telegram.Bots.Types.Message;

namespace Backend.Core.Application.Features.Administration.Profiles
{
    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<Case, CaseDTO>()
                .ForMember(dto => dto.Id, expression => expression.MapFrom(@case => @case.Id))
                .ForMember(dto => dto.Status,
                    expression => expression.MapFrom(@case => @case.Status.ToString().ToLower()));
        }
    }
}