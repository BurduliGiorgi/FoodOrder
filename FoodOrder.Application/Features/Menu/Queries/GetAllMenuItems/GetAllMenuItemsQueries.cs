using FoodOrder.Application.Common;
using FoodOrder.Application.DTOs;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Queries.GetAllMenuItems
{
	public record GetAllMenuItemsQueries : IRequest<Result<List<MenuItemDto>>>;
}
