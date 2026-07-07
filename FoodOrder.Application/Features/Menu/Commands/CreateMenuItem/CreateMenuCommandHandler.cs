using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands.CreateMenuItem
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuItemCommand, Result<string>>
    {
        private readonly IMenuService _menuService;

        public CreateMenuCommandHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<Result<string>> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            return await _menuService.AddMenuItemAsync(request.Name, request.Price, request.Category);
        }
    }
}
