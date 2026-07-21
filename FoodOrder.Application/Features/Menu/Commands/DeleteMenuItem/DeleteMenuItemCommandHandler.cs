using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands.DeleteMenuItem
{
    public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand, Result<string>>
    {
        private readonly IMenuService _menuService;

        public DeleteMenuItemCommandHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<Result<string>> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
          return await _menuService.DeleteMenuItemAsync(request.Id);
        }
    }
}
