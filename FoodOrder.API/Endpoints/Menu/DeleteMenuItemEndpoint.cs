using FoodOrder.Application.Features.Menu.Commands.DeleteMenuItem;
using FoodOrder.Domain.Constants;
using MediatR;

namespace FoodOrder.API.Endpoints.Menu
{
    public class DeleteMenuItemEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/menu-items/{id}", async (Guid Id, IMediator mediator) =>
            {
                var command = new DeleteMenuItemCommand(Id);
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }).RequireAuthorization(policy => policy.RequireRole(Roles.Admin));
        }
    }
}
