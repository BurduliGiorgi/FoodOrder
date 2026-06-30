namespace FoodOrder.Application.Common.Interfaces
{
    public interface ITokenService
    {
        (string Token, DateTime ExpiresAt) CreateToken(Guid userId, string email, IList<string> roles);
        string CreateRefreshToken();
    }
}