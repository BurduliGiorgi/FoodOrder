//using FoodOrder.Application.Features.Menu.Commands.UpdateMenuItem;
//using MediatR;

//namespace FoodOrder.API.Endpoints.Menu
//{
//    public class UpdateMenuItemEndPoint : IEndpoint
//    {
//        public void MapEndpoint(IEndpointRouteBuilder app)
//        {
//           app.MapPut("/menu/update-menu-item/{Id}", async (Guid Id, IMediator mediator) =>
//            {
//                var command = new UpdateMenuItemCommand(Id);
//                var result = await mediator.Send(command);
//                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
//            }).RequireAuthorization(policy => policy.RequireRole(Roles.Admin));
//        }
//    }
//}
