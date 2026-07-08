using AutoMapper;
using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Application.DTOs;
using FoodOrder.Application.Features.Menu.Queries.GetAllMenuItems;
using MediatR;

namespace FoodOrder.Application.Features.Menu.Commands.GetAllMenuItems
{
    public class GetAllMenuItemsQueriesHandler : IRequestHandler<GetAllMenuItemsQueries, Result<List<MenuItemDto>>>
    {
        private readonly IMenuService _repository;
        private readonly IMapper _mapper;

        public GetAllMenuItemsQueriesHandler(IMenuService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<MenuItemDto>>> Handle(GetAllMenuItemsQueries request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllMenuItemsAsync();
            var dtos = _mapper.Map<List<MenuItemDto>>(items);
            return Result<List<MenuItemDto>>.Success(dtos);
        }
    }
}
