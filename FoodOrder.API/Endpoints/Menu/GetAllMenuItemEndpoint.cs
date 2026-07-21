using FoodOrder.Application.Features.Menu.Queries.GetAllMenuItems;
using MediatR;

namespace FoodOrder.API.Endpoints.Menu
{
    public class GetAllMenuItemEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/menu/get-all-menu-item", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllMenuItemsQueries());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Error);
            });
        }
    }
}
