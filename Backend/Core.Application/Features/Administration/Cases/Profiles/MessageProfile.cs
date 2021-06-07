using AutoMapper;
using Backend.Core.Application.Features.Administration.Cases.DTOs;
using Telegram.Bots.Types;

namespace Backend.Core.Application.Features.Administration.Cases.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, LastMessageDTO>();
        }
    }
}