using AutoMapper;
using FoodOrder.Application.DTOs;
using FoodOrder.Domain.Models;

namespace FoodOrder.Application.Mappings
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItem, MenuItemDto>();
        }
    }
}
