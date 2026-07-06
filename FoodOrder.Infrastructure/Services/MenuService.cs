using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Domain.Enums;
using FoodOrder.Domain.Models;
using FoodOrder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Infrastructure.Services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<MenuItem> _repository;
        private readonly UnitOfWork _unitOfWork;

        public MenuService(IRepository<MenuItem> repository,UnitOfWork unitOfWork)
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

        public async void<Result<string>> DeleteMenuItemAsync(Guid id)
        {
            var menuItem = await _repository.GetByIdA(id);
            _repository.Delete(menuItem);

        }

        public Task<Result<IEnumerable<MenuItem>>> GetAllMenuItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<MenuItem>>> GetMenuItemsByCategoryAsync(MenuCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> UpdateMenuItemAsync(Guid id, string name, decimal price, MenuCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
