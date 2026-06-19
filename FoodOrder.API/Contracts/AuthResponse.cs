namespace FoodOrder.API.Contracts
{
    public record AuthResponse(
        Guid Id,
        string Email,
        IEnumerable<string> Roles,
        string Token,
        DateTime ExpiresAt);
}
