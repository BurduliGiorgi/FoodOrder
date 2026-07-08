using FoodOrder.Application.Common;
using FoodOrder.Domain.Enums;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands.CreateMenuItem
{
    public record CreateMenuItemCommand(string Name, decimal Price, MenuCategory Category) : IRequest<Result<string>>;
}
