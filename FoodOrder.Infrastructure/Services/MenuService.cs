using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Domain.Enums;
using FoodOrder.Domain.Models;

namespace FoodOrder.Infrastructure.Services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<MenuItem> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IRepository<MenuItem> repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> AddMenuItemAsync(string name, decimal price, MenuCategory category)
        {
            var menuItem = new MenuItem
            {
                Name = name,
                Price = price,
                Category = category
            };

            await _repository.AddAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();

            return Result<string>.Success("Menu item added successfully.");
        }

        public async Task<Result<string>> DeleteMenuItemAsync(Guid id)
        {
            var menuItem = await _repository.GetById(id);
            _repository.Delete(menuItem);
            await _unitOfWork.SaveChangesAsync();
            return Result<string>.Success("Menu item deleted successfully.");

        }

        public async Task<Result<IEnumerable<MenuItem>>> GetAllMenuItemsAsync()
        {
            return Result<IEnumerable<MenuItem>>.Success(await _repository.GetAllAsync());
        }


        public async Task<Result<IEnumerable<MenuItem>>> GetMenuItemsByCategoryAsync(MenuCategory category)
        {
            var menuItems = await _repository.GetAllAsync();
            var filteredItems = menuItems.Where(item => item.Category == category);
            return Result<IEnumerable<MenuItem>>.Success(filteredItems);

        }

        public async Task<Result<string>> UpdateMenuItemAsync(Guid id)
        {
            var menuItem = await _repository.GetById(id);
            _repository.Update(menuItem);
            await _unitOfWork.SaveChangesAsync();
            return Result<string>.Success("Menu item updated successfully.");
        }
    }
}
