using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;
using FoodOrder.Application.DTOs;
using MediatR;

namespace FoodOrder.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResponse>>
    {
        readonly IAuthService _AuthService;
        public RefreshTokenCommandHandler(IAuthService authService)
        {
            _AuthService = authService;
        }
        public async Task<Result<AuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _AuthService.RefreshTokenAsync(request.RefreshToken, cancellationToken);  
        }
    }
}
