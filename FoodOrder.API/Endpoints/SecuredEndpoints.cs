using FoodOrder.Domain.Constants;
using System.Security.Claims;

namespace FoodOrder.API.Endpoints
{
    public static class SecuredEndpoints
    {
        public static void MapSecuredEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/secured").WithTags("Secured");

            group.MapGet("/", (ClaimsPrincipal user) =>
                    Results.Ok($"Hello {user.Identity?.Name}, you reached a protected endpoint."))
                .RequireAuthorization();

            group.MapGet("/admin", () =>
                    Results.Ok("Hello Admin, this endpoint is for administrators only."))
                .RequireAuthorization(policy => policy.RequireRole(Roles.Admin));
        }
    }
}