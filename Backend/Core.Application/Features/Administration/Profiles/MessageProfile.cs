using AutoMapper;
using Backend.Core.Application.Features.Administration.DTOs;
using Telegram.Bots.Types;

namespace Backend.Core.Application.Features.Administration.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, LastMessageDTO>();
        }
    }
}