using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator() {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
