using AutoMapper;
using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Application.DTOs;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace FoodOrder.Application.Features.Menu.Queries.GetMenuItemsByCategory
{
    public class GetMenuItemsByCategoryQueriesHandler : IRequestHandler<GetMenuItemsByCategoryQueries, Result<List<MenuItemDto>>>
    {
        private readonly IMenuService _repository;
        private readonly IMapper _mapper;

        public GetMenuItemsByCategoryQueriesHandler(IMenuService menuService,IMapper mapper)
        {
            _repository = menuService;
            _mapper = mapper;
        }


        public async Task<Result<List<MenuItemDto>>> Handle(GetMenuItemsByCategoryQueries request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetMenuItemsByCategoryAsync(request.Category);

            if (!result.IsSuccess || result.Value == null || !result.Value.Any())
            {
                return Result<List<MenuItemDto>>.Failure("No menu items found for the specified category.");
            }

            var menuItemDtos = _mapper.Map<List<MenuItemDto>>(result.Value);
            return Result<List<MenuItemDto>>.Success(menuItemDtos);
        }
    }
}
