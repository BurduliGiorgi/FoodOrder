using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Application.DTOs;
using FoodOrder.Domain.Constants;
using FoodOrder.Domain.Entities;
using FoodOrder.Infrastructure.Configuration;
using FoodOrder.Infrastructure.Data;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
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
    }
}