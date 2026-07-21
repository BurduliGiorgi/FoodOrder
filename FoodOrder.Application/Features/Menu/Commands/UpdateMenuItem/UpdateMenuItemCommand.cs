using FoodOrder.Application.Common;
using FoodOrder.Domain.Enums;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands.UpdateMenuItem
{
    public record UpdateMenuItemCommand(Guid Id, string Name, decimal Price, MenuCategory Category)
    : IRequest<Result<string>>;
}
