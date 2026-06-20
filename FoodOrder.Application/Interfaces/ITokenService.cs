using FoodOrder.Application.DTOs;

namespace FoodOrder.Application.Interfaces
{
    public interface ITokenService
    {
        (string Token, DateTime ExpiresAt) CreateToken(TokenRequest user, IEnumerable<string> roles);
    }
}