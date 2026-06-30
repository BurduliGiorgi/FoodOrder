using FluentValidation;

namespace FoodOrder.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandValidator : AbstractValidator<RevokeCommand>
    {
        public RevokeCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
