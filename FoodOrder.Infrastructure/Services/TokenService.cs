using FoodOrder.Application.DTOs;
using FoodOrder.Application.Interfaces;
using FoodOrder.Infrastructure.Configuration;
using FoodOrder.Infrastructure.Data;
using FoodOrder.Infrastructure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FoodOrder.Infrastructure.Services
{
    public class TokenService(IOptions<JwtSettings> jwtSettings) : ITokenService
    {
        private readonly JwtSettings _settings = jwtSettings.Value;

        public (string Token, DateTime ExpiresAt) CreateToken(TokenRequest user, IEnumerable<string> roles)
        {
            var expiresAt = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);

            var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new(JwtRegisteredClaimNames.Email, user.Email!),
        new(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            claims.AddRange(roles.Select(role => new Claim("role", role)));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiresAt,
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                SigningCredentials = credentials
            };

            var handler = new JsonWebTokenHandler();
            var token = handler.CreateToken(descriptor);

            return (token, expiresAt);
        }

        public string CreateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes);
        }

        public async Task RevokeAllActiveTokensAsync(AppDbContext db, Guid userId)
        {
            var activeTokens = db.RefreshTokens.Where(t => t.UserId == userId && t.IsActive).ToList();
            foreach (var token in activeTokens)
            {
                token.Revoked = DateTime.UtcNow;
            }
            await db.SaveChangesAsync();
        }
    }
}