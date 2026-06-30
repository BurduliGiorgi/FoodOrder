using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using MediatR;


namespace FoodOrder.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommand, Result<string>>
    {
        private readonly IAuthService _authService;   
        public RevokeCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<Result<string>> Handle(RevokeCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RevokeTokenAsync(request.RefreshToken, cancellationToken);
        }
    }
}
