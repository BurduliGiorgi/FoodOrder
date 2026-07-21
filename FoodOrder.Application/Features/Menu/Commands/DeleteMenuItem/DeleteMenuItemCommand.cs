using FoodOrder.Application.Common;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands.DeleteMenuItem
{
    public record DeleteMenuItemCommand(Guid Id) : IRequest<Result<string>>;
}
