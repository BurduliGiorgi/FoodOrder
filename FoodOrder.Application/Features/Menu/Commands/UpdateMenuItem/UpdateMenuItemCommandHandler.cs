using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands.UpdateMenuItem
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, Result<string>>
    {
        private readonly IMenuService _menuService;
        public UpdateMenuItemCommandHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<Result<string>> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            return await _menuService.UpdateMenuItemAsync(request.Id, request.Name, request.Price, request.Category);
        }
    }
}
