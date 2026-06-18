using AutoMapper;
using FoodOrder.Application.DTOs;
using FoodOrder.Infrastructure.Identity;

namespace FoodOrder.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, AppUserDTO>()
                .ForCtorParam("Roles", opt => opt.MapFrom(_ => new List<string>()));
        }
    }
}