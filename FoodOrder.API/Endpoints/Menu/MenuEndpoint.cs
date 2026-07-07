using FoodOrder.Application.Features.Menu.Commands;
using FoodOrder.Domain.Constants;
using MediatR;

namespace FoodOrder.API.Endpoints.Menu
{
    public class MenuEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            
            app.MapPost("/Menu/CreateMenuItem", async (MenuCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }).RequireAuthorization(policy => policy.RequireRole(Roles.Admin));
        }
    }
}

