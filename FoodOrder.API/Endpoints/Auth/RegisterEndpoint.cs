using FoodOrder.API.Contracts;
using FoodOrder.Domain.Constants;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace FoodOrder.API.Endpoints.Auth
{
    public class RegisterEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/auth/register", RegisterAsync);
        }

        private static async Task<IResult> RegisterAsync(
            RegisterRequest request,
            UserManager<AppUser> userManager)
        {
            if (await userManager.FindByEmailAsync(request.Email) is not null)
                return Results.BadRequest(new { Message = "User with this email already exists." });

            var user = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email
                
            };

            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return Results.BadRequest(result.Errors.Select(e => e.Description));

            await userManager.AddToRoleAsync(user, Roles.User);
            return Results.Ok($"User '{request.Email}' registered successfully.");
        }
    }
}