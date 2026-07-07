using FoodOrder.Domain.Enums;
using FoodOrder.Domain.Models;

namespace FoodOrder.Application.Common.Interfaces
{
    public interface IMenuService
    {

        Task<Result<string>> AddMenuItemAsync(string name, decimal price, MenuCategory category);

        Task<Result<IEnumerable<MenuItem>>> GetAllMenuItemsAsync();

        Task<Result<IEnumerable<MenuItem>>> GetMenuItemsByCategoryAsync(MenuCategory category);

        Task<Result<string>> UpdateMenuItemAsync(Guid id);

        Task<Result<string>> DeleteMenuItemAsync(Guid id);
    }
}