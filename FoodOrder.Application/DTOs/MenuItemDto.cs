using FoodOrder.Domain.Enums;

namespace FoodOrder.Application.DTOs
{
    public class MenuItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MenuCategory Category { get; set; }
    }
}
