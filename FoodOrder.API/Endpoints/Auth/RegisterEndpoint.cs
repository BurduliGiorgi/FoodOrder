using FoodOrder.Application.Features.Auth.Commands.Register;
using MediatR;

namespace FoodOrder.API.Endpoints.Auth
{
    public class RegisterEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/auth/register", async (RegisterCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            });
        } 

        
    }
}