using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands
{
    public class MenuCommandHandler : IRequestHandler<MenuCommand, Result<string>>
    {
        private readonly IMenuService _menuService;

        public MenuCommandHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<Result<string>> Handle(MenuCommand request, CancellationToken cancellationToken)
        {
            return await _menuService.AddMenuItemAsync(request.Name, request.Price, request.Category);
        }
    }
}
