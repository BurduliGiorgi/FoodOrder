using FoodOrder.Application.DTOs;

namespace FoodOrder.Application.Interfaces
{
    public interface ITokenService
    {
        (string Token, DateTime ExpiresAt) CreateToken(AppUserDTO user, IEnumerable<string> roles);
    }
}