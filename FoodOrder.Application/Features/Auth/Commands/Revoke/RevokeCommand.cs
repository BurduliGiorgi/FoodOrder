using FoodOrder.Application.Common;
using MediatR;

namespace FoodOrder.Application.Features.Auth.Commands.Revoke
{
    public record RevokeCommand(string RefreshToken) : IRequest<Result<string>>;    
}
