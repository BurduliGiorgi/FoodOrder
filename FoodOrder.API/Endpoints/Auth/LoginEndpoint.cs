using AutoMapper;
using FoodOrder.API.Contracts;
using FoodOrder.Application.DTOs;
using FoodOrder.Application.Interfaces;
using FoodOrder.Infrastructure.Configuration;
using FoodOrder.Infrastructure.Data;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using FoodOrder.Domain.Entities;

namespace FoodOrder.API.Endpoints.Auth;

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
        IMapper mapper,
        IOptions<JwtSettings> jwtSettings,
        AppDbContext db)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
            return Results.Unauthorized();

        var roles = await userManager.GetRolesAsync(user);
        var tokenRequest = mapper.Map<TokenRequest>(user);
        var (accessToken, accessExpiresAt) = tokenService.CreateToken(tokenRequest, roles);

        var refreshToken = tokenService.CreateRefreshToken();
        var refreshExpiresAt = DateTime.UtcNow.AddDays(jwtSettings.Value.RefreshTokenExpiryDays);

        db.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            UserId = user.Id,
            Created = DateTime.UtcNow,
            Expires = refreshExpiresAt
        });
        await db.SaveChangesAsync();

        return Results.Ok(new AuthResponse(
            user.Id, user.Email!, roles,
            accessToken, accessExpiresAt,
            refreshToken, refreshExpiresAt));
    }
}