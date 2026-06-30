using FoodOrder.Application.DTOs;

namespace FoodOrder.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<Result<string>> RegisterAsync(string firstName, string lastName, string email, string password);
        Task<Result<AuthResponse>> LoginAsync(string email, string password);
        Task<Result<AuthResponse>> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken);
        Task<Result<string>> RevokeTokenAsync(string refreshToken, CancellationToken cancellationToken);
    }
}
