using AutoMapper;
using Backend.Core.Application.Features.Correspondence.DTOs;
using Backend.Core.Domain.Entities;

namespace Backend.Core.Application.Features.Correspondence.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>()
                .ForMember(dto => dto.Id, expression => expression.MapFrom(client => client.Id))
                .ForMember(dto => dto.FirstName, expression => expression.MapFrom(client => client.FirstName))
                .ForMember(dto => dto.LastName, expression => expression.MapFrom(client => client.LastName));
        }
    }
}