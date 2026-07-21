using FoodOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.DTOs
{
    public class UpdateMenuItemRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MenuCategory Category { get; set; }
    }
}

