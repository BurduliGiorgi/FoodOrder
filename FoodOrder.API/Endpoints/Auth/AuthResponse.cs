namespace FoodOrder.API.Endpoints.Auth
{
    public record AuthResponse(
        Guid Id,
        string Email,
        IEnumerable<string> Roles,
        string Token,
        DateTime ExpiresAt);
}
