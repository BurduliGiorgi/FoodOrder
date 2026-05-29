using FoodOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Domain.Models
{
    public class OrderItem : BaseClass
    {
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string MenuItemName { get; set; }
        public decimal UnitPrice { get; set; }     
        public string SpecialInstructions { get; set; } 

        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
