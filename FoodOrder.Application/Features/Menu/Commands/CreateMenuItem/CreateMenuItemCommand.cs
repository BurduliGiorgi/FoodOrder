using FoodOrder.Application.Common;
using FoodOrder.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Features.Menu.Commands.CreateMenuItem
{
    public record CreateMenuItemCommand(string Name, decimal Price, MenuCategory Category) : IRequest<Result<string>>;
}
