using AutoMapper;
using Backend.Core.Application.Features.Correspondence.DTOs;
using Backend.Core.Domain.Entities;

namespace Backend.Core.Application.Features.Correspondence.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDTO>()
                .ForMember(dto => dto.Type,
                    expression => expression.MapFrom(message => message.Type.ToString().ToLower()))
                .ForMember(dto => dto.CreatedAt, expression => expression.MapFrom(message => message.CreatedAt));
        }
    }
}