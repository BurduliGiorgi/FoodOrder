namespace FoodOrder.Domain.Common
{
    public abstract class BaseClass
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdateAt { get; set; }  

        public DateTime DeleteAt { get; set; }  

        public bool IsDeleted { get; set; } = false;
    }
}
