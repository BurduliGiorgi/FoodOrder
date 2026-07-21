using FoodOrder.Application.DTOs;
using FoodOrder.Application.Features.Menu.Commands.UpdateMenuItem;
using FoodOrder.Domain.Constants;
using MediatR;

namespace FoodOrder.API.Endpoints.Menu
{
    public class UpdateMenuItemEndPoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/menu-items/{id}", async (Guid id, UpdateMenuItemRequest request, IMediator mediator) =>
            {
                var command = new UpdateMenuItemCommand(id, request.Name, request.Price, request.Category);
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }).RequireAuthorization(policy => policy.RequireRole(Roles.Admin));
        }
    }
}