using MediatR;

namespace FoodOrder.API.Endpoints.Menu
{
    public class MenuEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/Menu/ShowMenu", async (MenuCommand command,IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }
        }
    }
}
