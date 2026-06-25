using FoodOrder.Application.DTOs;

namespace FoodOrder.Application.Common.Interfaces
{
    public interface ITokenService
    {
        (string Token, DateTime ExpiresAt) CreateToken(TokenRequest user, IEnumerable<string> roles);
        string CreateRefreshToken();
    }
}