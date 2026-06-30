namespace FoodOrder.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public string Token { get; set; } 

        public Guid UserId { get; set; } 

        public DateTime Created { get; set; } 

        public DateTime Expires { get; set; }

        public DateTime? Revoked { get; set; }

        public string? ReplacedByToken { get; set; }

        public bool IsActive => Revoked is null && DateTime.UtcNow < Expires;

    }
}
