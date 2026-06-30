using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Application.DTOs;
using FoodOrder.Domain.Constants;
using FoodOrder.Domain.Entities;
using FoodOrder.Infrastructure.Configuration;
using FoodOrder.Infrastructure.Data;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodOrder.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _dbContext;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, AppDbContext dbContext, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _dbContext = dbContext;
            _jwtSettings = jwtSettings;
        }

        public async Task<Result<AuthResponse>> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, password))
                return Result<AuthResponse>.Failure("Invalid email or password.");

            var roles = await _userManager.GetRolesAsync(user);

            var (token, expiresAt) = _tokenService.CreateToken(user.Id, user.Email!, roles);

            var refreshToken = new RefreshToken
            {
                Token = _tokenService.CreateRefreshToken(),
                UserId = user.Id,
                Expires = DateTime.UtcNow.AddDays(_jwtSettings.Value.RefreshTokenExpiryDays),
                Created = DateTime.UtcNow
            };

            _dbContext.RefreshTokens.Add(refreshToken);
            await _dbContext.SaveChangesAsync();

            var response = new AuthResponse(
                user.Id,
                user.Email!,
                roles,
                token,
                expiresAt,
                refreshToken.Token,
                refreshToken.Expires);

            return Result<AuthResponse>.Success(response);
        }

        public async Task<Result<string>> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                return Result<string>.Failure("User with this email already exists.");
            }

            var user = new AppUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
            };
            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded) {
                return Result<string>.Failure(result.Errors.First().Description);
            }
            await _userManager.AddToRoleAsync(user, Roles.User);
            return Result<string>.Success("User registered successfully.");
        }
        public async Task<Result<AuthResponse>> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken)
        {
            var token = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken, cancellationToken);

            if (token is null)
            {
                return Result<AuthResponse>.Failure("Invalid refresh token.");
            }

            if (token.Revoked is not null)
            {
                await RevokeAllActiveTokensAsync(token.UserId, cancellationToken);
                return Result<AuthResponse>.Failure("Token reuse detected.");
            }

            if (token.Expires < DateTime.UtcNow)
            {
                return Result<AuthResponse>.Failure("Refresh token expired.");
            }

            var user = await _userManager.FindByIdAsync(token.UserId.ToString());
            if (user is null)
            {
                return Result<AuthResponse>.Failure("User not found.");
            }

            var roles = await _userManager.GetRolesAsync(user);

            token.Revoked = DateTime.UtcNow;

            var accessToken = _tokenService.CreateToken(user.Id, user.Email!, roles);
            var newRefreshToken = _tokenService.CreateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                Token = newRefreshToken,
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };

            _dbContext.RefreshTokens.Add(refreshTokenEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<AuthResponse>.Success(new AuthResponse(
                user.Id,
                user.Email!,
                roles,
                accessToken.Token,
                accessToken.ExpiresAt,
                newRefreshToken,
                refreshTokenEntity.Expires));
        }

        private async Task RevokeAllActiveTokensAsync(Guid userId, CancellationToken cancellationToken)
        {
            var activeTokens = await _dbContext.RefreshTokens
                .Where(t => t.UserId == userId && t.Revoked == null)
                .ToListAsync(cancellationToken);

            foreach (var token in activeTokens)
            {
                token.Revoked = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result<string>> RevokeTokenAsync(string refreshToken, CancellationToken cancellationToken)
        {
            var token = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(t => t.Token == refreshToken, cancellationToken);

            if (token is null || token.Revoked is not null)
            {
                return Result<string>.Failure("Token not found or already inactive.");
            }

            token.Revoked = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success("Refresh token revoked.");
        }
    }
}