//using FoodOrder.Application.Features.Menu.Commands.DeleteMenuItem;
//using MediatR;

//namespace FoodOrder.API.Endpoints.Menu
//{
//    public class DeleteMenuItemEndPoint : IEndpoint
//    {
//        public void MapEndpoint(IEndpointRouteBuilder app)
//        {
//            app.MapDelete("/menu/delete-menu-item/{Id}", async (Guid Id, IMediator mediator) =>
//            {
//                var command = new DeleteMenuItemCommand(Id);
//                var result = await mediator.Send(command);
//                return result.IsSu ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
//            }).RequireAuthorization(policy => policy.RequireRole(Roles.Admin)); 
//        }
//    }
//}
