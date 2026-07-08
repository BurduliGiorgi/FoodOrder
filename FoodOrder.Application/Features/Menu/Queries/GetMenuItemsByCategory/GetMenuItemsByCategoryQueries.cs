using FoodOrder.Application.Common;
using FoodOrder.Application.DTOs;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Queries.GetMenuItemsByCategory
{
	public class GetMenuItemsQuery(Guid? CategoryId = null) : IRequest<Result<List<MenuItemDto>>>;
}
