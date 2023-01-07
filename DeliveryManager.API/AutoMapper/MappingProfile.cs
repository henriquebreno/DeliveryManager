using AutoMapper;
using DeliveryManager.Application.Dtos;
using DeliveryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryManager.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap().ForMember(dest => dest.Id, opt=>opt.MapFrom(src => src.ClientId));

            CreateMap<ClientAddress, ClientAddressDto>()
                .ReverseMap();


        }
    }
}
