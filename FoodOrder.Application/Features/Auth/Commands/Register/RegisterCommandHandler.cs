using MediatR;
using FoodOrder.Application.Common;
using FoodOrder.Application.Common.Interfaces;

namespace FoodOrder.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<string>>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService; 
        }

        public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterAsync(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
        }

}
}