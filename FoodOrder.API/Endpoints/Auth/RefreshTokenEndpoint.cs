//using FoodOrder.API.Contracts;
//using FoodOrder.Application.DTOs;
//using FoodOrder.Infrastructure.Configuration;
//using FoodOrder.Infrastructure.Data;
//using FoodOrder.Infrastructure.Identity;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Options;
//using Microsoft.EntityFrameworkCore;
//using AutoMapper;
//using FoodOrder.Domain.Entities;
//using FoodOrder.Application.Common.Interfaces;

//namespace FoodOrder.API.Endpoints.Auth;

//public class RefreshTokenEndpoint : IEndpoint
//{
//    public void MapEndpoint(IEndpointRouteBuilder app)
//    {
//        app.MapPost("/api/auth/refresh", RefreshAsync);
//        app.MapPost("/api/auth/revoke", RevokeAsync);
//    }

//    private static async Task<IResult> RefreshAsync(
//        RefreshRequest request,
//        UserManager<AppUser> userManager,
//        ITokenService tokenService,
//        IMapper mapper,
//        IOptions<JwtSettings> jwtSettings,
//        AppDbContext db)
//    {
//        var existing = await db.RefreshTokens
//            .FirstOrDefaultAsync(t => t.Token == request.RefreshToken);

//        if (existing is null)
//            return Results.Unauthorized();

//        if (!existing.IsActive)
//        {

//            if (existing.Revoked is not null)
//                await RevokeAllActiveTokensAsync(db, existing.UserId);

//            return Results.Unauthorized();
//        }

//        existing.Revoked = DateTime.UtcNow;

//        var user = await userManager.FindByIdAsync(existing.UserId.ToString());
//        if (user is null)
//            return Results.Unauthorized();

//        var roles = await userManager.GetRolesAsync(user);
//        var tokenRequest = mapper.Map<TokenRequest>(user);
//        var (accessToken, accessExpiresAt) = tokenService.CreateToken(, roles);

//        var newRefreshToken = tokenService.CreateRefreshToken();
//        var refreshExpiresAt = DateTime.UtcNow.AddDays(jwtSettings.Value.RefreshTokenExpiryDays);

//        db.RefreshTokens.Add(new RefreshToken
//        {
//            Token = newRefreshToken,
//            UserId = user.Id,
//            Created = DateTime.UtcNow,
//            Expires = refreshExpiresAt
//        });
//        await db.SaveChangesAsync();

//        return Results.Ok(new AuthResponse(
//            user.Id, user.Email!, roles,
//            accessToken, accessExpiresAt,
//            newRefreshToken, refreshExpiresAt));
//    }

//    private static async Task RevokeAllActiveTokensAsync(AppDbContext db, Guid userId)
//    {
//        var activeTokens = await db.RefreshTokens
//            .Where(t => t.UserId == userId && t.Revoked == null)
//            .ToListAsync();

//        foreach (var token in activeTokens)
//        {
//            token.Revoked = DateTime.UtcNow;
//        }

//        await db.SaveChangesAsync();
//    }
//    private static async Task<IResult> RevokeAsync(RevokeRequest request, AppDbContext db)
//    {
//        var token = await db.RefreshTokens
//            .FirstOrDefaultAsync(t => t.Token == request.RefreshToken);

//        if (token is null || !token.IsActive)
//        {
//            return Results.NotFound("Token not found or already inactive.");
//        }

//        token.Revoked = DateTime.UtcNow;
//        await db.SaveChangesAsync();
//        return Results.Ok("Refresh token revoked.");
//    }
//}