using FoodOrder.Application.Features.Menu.Commands.DeleteMenuItem;
using MediatR;

namespace FoodOrder.API.Endpoints.Menu
{
    public class DeleteMenuItemEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/Menu/DeleteMenuItem", async (DeleteMenuItemCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }).RequireAuthorization(policy => policy.RequireRole(Roles.Admin)); 
        }
    }
}
