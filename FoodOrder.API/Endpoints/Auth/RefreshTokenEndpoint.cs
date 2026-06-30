using FoodOrder.Application.Features.Auth.Commands.RefreshToken;
using FoodOrder.Application.Features.Auth.Commands.Revoke;
using MediatR;

namespace FoodOrder.API.Endpoints.Auth;

public class RefreshTokenEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/refresh", async (RefreshTokenCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        });

        app.MapPost("/api/auth/revoke", async (RevokeCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
        });
    }
}