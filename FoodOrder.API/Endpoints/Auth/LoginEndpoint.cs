using FoodOrder.Application.Features.Auth.Commands.Login;
using MediatR;

namespace FoodOrder.API.Endpoints.Auth;

public class LoginEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", async (LoginCommand command,IMediator mediator) =>
        {
           var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        });
    }

}