using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password);
}
