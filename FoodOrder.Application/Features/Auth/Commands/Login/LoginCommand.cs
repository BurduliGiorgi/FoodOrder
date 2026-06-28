using FoodOrder.Application.Common;
using FoodOrder.Application.DTOs;
using MediatR;

namespace FoodOrder.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<Result<AuthResponse>>;
}
