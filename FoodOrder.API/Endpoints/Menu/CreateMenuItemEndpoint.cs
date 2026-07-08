using FoodOrder.Application.Features.Menu.Commands.CreateMenuItem;
using FoodOrder.Domain.Constants;
using MediatR;

namespace FoodOrder.API.Endpoints.Menu
{
    public class CreateMenuItemEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            
            app.MapPost("/menu/create-menu-item", async (CreateMenuItemCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }).RequireAuthorization(policy => policy.RequireRole(Roles.Admin));
        }
    }
}

