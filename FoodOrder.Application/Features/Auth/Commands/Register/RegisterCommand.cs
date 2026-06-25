using MediatR;
using FoodOrder.Application.Common;
namespace FoodOrder.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<Result<string>>;
}
