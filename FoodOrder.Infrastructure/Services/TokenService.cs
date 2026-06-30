using Azure.Core;
using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Application.DTOs;
using FoodOrder.Application.Features.Auth.Commands.RefreshToken;
using FoodOrder.Domain.Entities;
using FoodOrder.Infrastructure.Configuration;
using FoodOrder.Infrastructure.Data;
using FoodOrder.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FoodOrder.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _settings;

        public TokenService(IOptions<JwtSettings> jwtSettings)
        {
            _settings = jwtSettings.Value;
        }

        public (string Token, DateTime ExpiresAt) CreateToken(Guid userId, string email, IList<string> roles)
        {
            var expiresAt = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(JwtRegisteredClaimNames.Email, email),
                new(JwtRegisteredClaimNames.Name, email),
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

        
    }
}