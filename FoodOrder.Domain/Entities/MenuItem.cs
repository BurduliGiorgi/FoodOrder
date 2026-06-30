using FoodOrder.Domain.Common;
using FoodOrder.Domain.Enums;

namespace FoodOrder.Domain.Models
{
    public class MenuItem : BaseClass
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MenuCategory Category { get; set; }
    }
}

