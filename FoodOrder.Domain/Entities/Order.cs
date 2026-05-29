using FoodOrder.Domain.Common;
using FoodOrder.Domain.Enums;
using FoodOrder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
