using FoodOrder.Application.Common;
using FoodOrder.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Features.Menu.Commands
{
    public record MenuCommand(string Name, decimal Price, MenuCategory Category) : IRequest<Result<string>>;
}
