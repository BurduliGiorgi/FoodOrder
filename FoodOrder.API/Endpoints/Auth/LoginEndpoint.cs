using AutoMapper;
using FoodOrder.API.Contracts;
using FoodOrder.Application.DTOs;
using FoodOrder.Application.Interfaces;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;


namespace FoodOrder.API.Endpoints.Auth
{
    public class LoginEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/auth/login", LoginAsync);
        }

        private static async Task<IResult> LoginAsync(
            LoginRequest request,
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
                return Results.Unauthorized();

            var roles = await userManager.GetRolesAsync(user);
            var userDto = mapper.Map<TokenRequest>(user);
            var (token, expiresAt) = tokenService.CreateToken(userDto, roles);
            return Results.Ok(new AuthResponse(user.Id, user.Email!, roles, token, expiresAt));
        }
    }
}