using FoodOrder.Application.Common;
using FoodOrder.Application.DTOs;
using FoodOrder.Domain.Enums;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Queries.GetMenuItemsByCategory
{
	public record GetMenuItemsByCategoryQueries(MenuCategory Category) : IRequest<Result<List<MenuItemDto>>>;
}
