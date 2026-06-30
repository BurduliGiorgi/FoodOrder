using FoodOrder.Application.Common;
using FoodOrder.Application.DTOs;
using MediatR;

namespace FoodOrder.Application.Features.Auth.Commands.RefreshToken
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<Result<AuthResponse>>;
}
