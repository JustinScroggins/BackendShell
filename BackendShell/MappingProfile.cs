using AutoMapper;
using Entities;
using Entities.Models;
using Shared.DataTransferObjects;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<OrderForUpdateDto, Order>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
