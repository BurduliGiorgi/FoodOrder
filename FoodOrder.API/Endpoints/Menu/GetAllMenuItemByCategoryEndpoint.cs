using FoodOrder.Application.Features.Menu.Queries.GetMenuItemsByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.API.Endpoints.Menu
{
    public class GetAllMenuItemByCategoryEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/get-menu-items-by-category", async (
        [FromBody] GetMenuItemsByCategoryQueries command,
         [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            });
        }
    }
}
