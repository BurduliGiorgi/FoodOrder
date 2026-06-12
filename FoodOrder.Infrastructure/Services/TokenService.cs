using FoodOrder.Application.Interfaces;
using FoodOrder.Infrastructure.Configuration;
using FoodOrder.Infrastructure.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Infrastructure.Services
{
    public class TokenService(IOptions<JwtSettings> jwtSettings) : ITokenService
    {
        private readonly JwtSettings _settings = jwtSettings.Value;

        public (string Token,DateTime ExpiresAt) CreateToken(AppUser user, IEnumerable<string> roles)
        {

        }
    }
}
