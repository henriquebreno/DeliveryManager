using AutoMapper;
using DeliveryManager.Application.Dtos;
using DeliveryManager.Application.Dtos.Address;
using DeliveryManager.Application.Dtos.Client;
using DeliveryManager.Domain.Entities;
using System;

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
                .ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientId));


            CreateMap<ClientAddress, ClientAddressDto>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AddressId));


        }
    }
}
