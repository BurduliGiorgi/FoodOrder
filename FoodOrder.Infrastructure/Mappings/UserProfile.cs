using AutoMapper;
using FoodOrder.Application.DTOs;
using FoodOrder.Infrastructure.Identity;

namespace FoodOrder.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, TokenRequest>();

        }
    }
}