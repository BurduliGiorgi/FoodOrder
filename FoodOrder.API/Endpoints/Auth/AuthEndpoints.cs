using FoodOrder.API.Contracts;
using FoodOrder.Domain.Constants;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace FoodOrder.API.Endpoints.Auth
{
    public class AuthEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/add-role", AddRoleAsync)
            .RequireAuthorization(policy => policy.RequireRole(Roles.Admin));
        }

        private static async Task<IResult> AddRoleAsync(
        AddRoleRequest request,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole<Guid>> roleManager)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Results.NotFound($"No user found with email '{request.Email}'.");
            }

            if (!await roleManager.RoleExistsAsync(request.Role))
            {
                return Results.BadRequest($"Role '{request.Role}' does not exist.");
            }

            await userManager.AddToRoleAsync(user, request.Role);
            return Results.Ok($"Role '{request.Role}' added to '{request.Email}'.");
        }
    }
}
