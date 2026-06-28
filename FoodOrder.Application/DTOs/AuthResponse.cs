namespace FoodOrder.Application.DTOs
{
    public record AuthResponse(
        Guid Id,
        string Email,
        IEnumerable<string> Roles,
        string Token,
        DateTime ExpiresAt,
        string RefreshToken,
        DateTime RefreshTokenExpiresAt);
}
