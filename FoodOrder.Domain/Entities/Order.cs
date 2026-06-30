using FoodOrder.Domain.Common;
using FoodOrder.Domain.Enums;

namespace FoodOrder.Domain.Models
{
    public class Order : BaseClass
    {
        public Guid UserId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
